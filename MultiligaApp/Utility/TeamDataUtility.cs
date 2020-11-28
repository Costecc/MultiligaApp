using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiligaApp
{
    class TeamDataUtility
    {
        static public void createTeam(string name)
        {
            if (name.Length > 0)
            {
                using (var db = new multiligaEntities())
                {
                    var team = new druzyna { nazwa = name, id_kapitan = LoggedUserUtility.getLoggedContestant().id_zawodnik };
                    db.druzyna.Add(team);
                    var userTeam = new zawodnik_druzyna { id_druzyna = team.id_druzyna, id_zawodnik = LoggedUserUtility.getLoggedContestant().id_zawodnik };
                    db.zawodnik_druzyna.Add(userTeam);
                    db.SaveChanges();

                }
            }
        }

            static public List<IGrouping<int, druzyna>> selectTeams(string name, string competition, string city, string discipline)         //IGrouping, bo trzeba zrobić group by, żeby nie wyświetlało tej samej druzyny kilka razy
            {
                using (var db = new multiligaEntities())
                {
                    var teams = (from _druzyna in db.druzyna
                                 join _zawodnik_druzyna in db.zawodnik_druzyna on _druzyna.id_druzyna equals _zawodnik_druzyna.id_druzyna into _z_dr

                                 from _zawodnik_druzyna in _z_dr.DefaultIfEmpty()
                                 join _zawodnik_zawody in db.zawodnik_zawody on _zawodnik_druzyna.id_zawodnik equals _zawodnik_zawody.id_zawodnik into _zaw_zaw

                                 from _zawodnik_zawody in _zaw_zaw.DefaultIfEmpty()
                                 join _zawody in db.zawody on _zawodnik_zawody.id_zawody equals _zawody.id_zawody into _zaw

                                 from _zawody in _zaw.DefaultIfEmpty()
                                 join _wyscig in db.wyscig on _zawody.id_zawody equals _wyscig.id_zawody into _wys

                                 from _zawody2 in _zaw.DefaultIfEmpty()
                                 join _dyscyplina in db.dyscyplina on _zawody2.id_dyscyplina equals _dyscyplina.id_dyscyplina into _dys

                                 from _dyscyplina in _dys.DefaultIfEmpty()

                                 from _wyscig in _wys.DefaultIfEmpty()

                                 where (_druzyna.nazwa.Contains(name) && name != "") || (_wyscig.miasto.Contains(city) && city != "")
                                   || (_zawody.nazwa.Contains(competition) && competition != "") || _dyscyplina.nazwa.Contains(discipline) && discipline != ""

                                 select _druzyna
                                 ).GroupBy(z => z.id_druzyna).ToList();

                    return teams;
                }
            }

        static public void showTeamsProfile(ProfileForm profileForm, int userPermissions, int id)
        {
            druzyna selectedTeam;
            using (var db = new multiligaEntities())
            {
                selectedTeam = db.druzyna.FirstOrDefault(d => d.id_druzyna == id);
            }

            profileForm.FillProfileDataTeam(selectedTeam.nazwa,
                getTeamsCaptain(selectedTeam.id_kapitan).imie_nazwisko,
                getTeamsDisciplines(id),
                getTeamsCurrentCompetitions(id),
                getTeamsPastCompetitions(id),
                getTeamsAchievements(id, getRacesInMultipleCompetitions(getTeamsPastCompetitions(id))), // jesli zawodnik nie ma past comp to nic
                selectedTeam.informacja
                );
        }

        static public List<string> getTeamsDisciplines(int id)
        {
            using (var db = new multiligaEntities())
            {
                var disciplines = (from _druzyna in db.druzyna
                                   join _druzyna_zawody in db.druzyna_zawody on _druzyna.id_druzyna equals _druzyna_zawody.id_druzyna into _dr_zaw

                                   from _druzyna_zawody in _dr_zaw.DefaultIfEmpty()
                                   join _zawody in db.zawody on _druzyna_zawody.id_zawody equals _zawody.id_zawody into _zaw

                                   from _zawody in _zaw.DefaultIfEmpty()
                                   join _dyscyplina in db.dyscyplina on _zawody.id_dyscyplina equals _dyscyplina.id_dyscyplina into _dys

                                   from _dyscyplina in _dys.DefaultIfEmpty()

                                   where (_druzyna.id_druzyna == id)
                                   select _dyscyplina.nazwa
                                   ).ToList() ;
                return disciplines;
            }
        }

        static public zawodnik getTeamsCaptain(int id)
        {
            zawodnik captain;
            using (var db = new multiligaEntities())
            {
                captain = db.zawodnik.FirstOrDefault(z => z.id_zawodnik == id);
            }
            return captain;
        }

        static public List<zawody> getTeamsCurrentCompetitions(int id)  //zwraca listę nazw drużyn, do których należy zawodnik o podanym id, parametr onlyPastDates - czy podać jedynie ukończone zawody
        {
            List<zawody> competitions;

            using (var db = new multiligaEntities())
            {
                competitions = (from _druzyna in db.druzyna
                                join _druzyna_zawody in db.druzyna_zawody on _druzyna.id_druzyna equals _druzyna_zawody.id_druzyna into _dr_zaw

                                from _druzyna_zawody in _dr_zaw.DefaultIfEmpty()
                                join _zawody in db.zawody on _druzyna_zawody.id_zawody equals _zawody.id_zawody into _zaw
                                from _zawody in _zaw.DefaultIfEmpty()

                                where (_druzyna.id_druzyna == id && _zawody.data_koniec >= DateTime.Now)
                                select _zawody
                         ).ToList();

            }
            return competitions;
        }

        static public List<zawody> getTeamsPastCompetitions(int id)  //zwraca listę nazw drużyn, do których należy zawodnik o podanym id, parametr onlyPastDates - czy podać jedynie ukończone zawody
        {
            List<zawody> competitions;

            using (var db = new multiligaEntities())
            {
                competitions = (from _druzyna in db.druzyna
                                join _druzyna_zawody in db.druzyna_zawody on _druzyna.id_druzyna equals _druzyna_zawody.id_druzyna into _dr_zaw

                                from _druzyna_zawody in _dr_zaw.DefaultIfEmpty()
                                join _zawody in db.zawody on _druzyna_zawody.id_zawody equals _zawody.id_zawody into _zaw
                                from _zawody in _zaw.DefaultIfEmpty()

                                where (_druzyna.id_druzyna == id && _zawody.data_koniec < DateTime.Now)
                                select _zawody
                         ).ToList();

            }
            return competitions;
        }

        static public List<wyscig> getRacesInMultipleCompetitions(List<zawody> competitions)
        {
            var races = new List<wyscig>();
            using (var db = new multiligaEntities())
            {
                foreach (var c in competitions)
                {
                    var racesInComp = getRacesInSingleCompetition(c);
                    foreach (var r in racesInComp)
                    {
                        races.Add(r);
                    }
                }
            }
            return races;
        }

        static public List<wyscig> getRacesInSingleCompetition(zawody competition)
        {
            using (var db = new multiligaEntities())
            {
                return (from _wyscig in db.wyscig
                        where _wyscig.id_zawody == competition.id_zawody
                        select _wyscig).ToList();
            }
        }

        static public List<result> getTeamsAchievements(int id, List<wyscig> races)
        {
            var teamsAchievements = new List<result>();
            if (getTeamsPastCompetitions(id).Count > 0)
            {
                result overallResult;
                using (var db = new multiligaEntities())
                {
                    int previousCompetitionId = 0, raceNumber = 1;
                    foreach (var r in races)
                    {
                        if (previousCompetitionId == r.id_zawody)
                        {
                            ++raceNumber;
                        }
                        else if (previousCompetitionId != 0)
                        {
                            overallResult = getTeamsPlaceInCompetition(id, previousCompetitionId, sumTeamsTimeInCompetition(id, previousCompetitionId));
                            if (overallResult.place <= 3)
                            {
                                teamsAchievements.Add(overallResult);
                            }
                            raceNumber = 1;
                        }

                        var result = getTeamsRaceResult(id, r, raceNumber);
                        if (result.place <= 3)
                        {
                            teamsAchievements.Add(result);
                        }
                        previousCompetitionId = r.id_zawody;
                    }
                    overallResult = getTeamsPlaceInCompetition(id, previousCompetitionId, sumTeamsTimeInCompetition(id, previousCompetitionId));
                    if (overallResult.place <= 3)
                    {
                        teamsAchievements.Add(overallResult);
                    }
                }
            }
            return teamsAchievements;
        }
        
        static public result getTeamsRaceResult(int id, wyscig race, int raceNumber)
        {
            using (var db = new multiligaEntities())
            {
                var time = (from _wynik in db.wynik
                            join _zawodnik in db.zawodnik on _wynik.id_zawodnik equals _zawodnik.id_zawodnik into _zaw
                            from _zawodnik in _zaw.DefaultIfEmpty()

                            join _zawodnik_druzyna in db.zawodnik_druzyna on _zawodnik.id_zawodnik equals _zawodnik_druzyna.id_zawodnik into _zaw_dr
                            from _zawodnik_druzyna in _zaw_dr.DefaultIfEmpty()

                            where (_zawodnik_druzyna.id_druzyna == id && _wynik.id_wyscig == race.id_wyscig)
                            select _wynik).AsEnumerable().Sum(w => w.czas.Value.Ticks);

                var calculatedTime = TimeSpan.FromTicks(time);
                var racePlace = (from _wynik in db.wynik
                                 where (_wynik.czas < calculatedTime && _wynik.czas != TimeSpan.Zero && _wynik.id_wyscig == race.id_wyscig)
                                 select _wynik.czas).Count();
                var competitionName = db.zawody.Where(z => z.id_zawody == race.id_zawody).SingleOrDefault().nazwa;

                result r;
                r.place = racePlace + 1;
                r.competitionName = competitionName;
                r.points = 0;
                r.id = id;
                r.raceName = ", wyścig numer " + raceNumber.ToString();
                return r;
            }
        }

        static public long sumTeamsTimeInCompetition(int id, int competitionId)
        {
            using (var db = new multiligaEntities())
            {
                return (from _wynik in db.wynik
                        join _wyscig in db.wyscig on _wynik.id_wyscig equals _wyscig.id_wyscig     

                        join _zawodnik in db.zawodnik on _wynik.id_zawodnik equals _zawodnik.id_zawodnik into _zaw
                        from _zawodnik in _zaw.DefaultIfEmpty()

                        join _zawodnik_druzyna in db.zawodnik_druzyna on _zawodnik.id_zawodnik equals _zawodnik_druzyna.id_zawodnik into _zaw_dr
                        from _zawodnik_druzyna in _zaw_dr.DefaultIfEmpty()

                        where (_wyscig.id_zawody == competitionId && _zawodnik_druzyna.id_druzyna == id)
                        select _wynik).AsEnumerable().Sum(w => w.czas.Value.Ticks);
            }
        }
        //todo
        static public result getTeamsPlaceInCompetition(int id, int competitionId, long time)
        {
            using (var db = new multiligaEntities())
            {
                var aggregatedTimes = new List<long>();
                var joinedTables = (from _wynik in db.wynik
                                    join _wyscig in db.wyscig on _wynik.id_wyscig equals _wyscig.id_wyscig
                                    where _wyscig.id_zawody == competitionId
                                    select _wynik);

                var contestants = (from _zawodnik_zawody in db.zawodnik_zawody
                                   where _zawodnik_zawody.id_zawody == competitionId
                                   select _zawodnik_zawody.id_zawodnik);

                foreach (var c in contestants)
                {
                    var aggregatedTime = (from _joinedTables in joinedTables
                                          where _joinedTables.id_zawodnik == c
                                          select _joinedTables).AsEnumerable().Sum(s => s.czas.Value.Ticks);
                    //MessageBox.Show(TimeSpan.FromTicks(aggregatedTime).ToString(), "zawodnik" + c.ToString());
                    aggregatedTimes.Add(aggregatedTime);
                }
                var competitionName = db.zawody.Where(z => z.id_zawody == competitionId).SingleOrDefault().nazwa;
                var place = (from _aggregatedTime in aggregatedTimes
                             where time > _aggregatedTime
                             select _aggregatedTime).Count() + 1; // +1 bo wcześniej sprawdzam tylko ilu zawodników miało krótszy czas -> jeśli 0, to mamy 1 miejsce     
                result r;

                r.competitionName = competitionName + " KLASYFIKACJA GENERALNA";
                r.place = place;
                r.points = 0;
                r.id = id;
                r.raceName = "";
                return r;
            }
        }



        //nie wiem czy potrzebne
        static public bool checkIfCompetitionCompleted(int id, int competitionId)   //sprawdzam czy zawodnik brał udział we wszystkich wyścigach składających się na zawody
        {
            using (var db = new multiligaEntities())
            {
                var raceCount = (from _wynik in db.wynik
                                 join _wyscig in db.wyscig on _wynik.id_wyscig equals _wyscig.id_wyscig
                                 where _wyscig.id_zawody == competitionId
                                 select _wynik).Count();

                var resultCount = (from _wynik in db.wynik
                                   join _wyscig in db.wyscig on _wynik.id_wyscig equals _wyscig.id_wyscig
                                   where _wyscig.id_zawody == competitionId && _wynik.id_zawodnik == id && _wynik.czas != null
                                   select _wynik).Count();

                return raceCount == resultCount;
            }
        }

    }
}
