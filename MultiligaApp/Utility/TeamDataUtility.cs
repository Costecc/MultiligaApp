using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public struct teamResult
{
    public string competitionName, raceName;
    public int place, points, teamId;
};
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

        static public void showTeamsProfile(ProfileForm profileForm, int id)
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
                getTeamsAchievements(id, getTeamsPastCompetitions(id)), // jesli zawodnik nie ma past comp to nic
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

        static public List<teamResult> getTeamsAchievements(int id, List<zawody> competitions)
        {
            var teamsAchievements = new List<teamResult>();

            if (getTeamsPastCompetitions(id).Count > 0)
            {
                using (var db = new multiligaEntities())
                {
                    foreach (var competition in competitions)
                    {
                        var competitionResults = new List<teamResult>();

                        var races = (from _wyscig in db.wyscig
                                     where _wyscig.id_zawody == competition.id_zawody
                                     select _wyscig);

                        var contestantsIds = (from _zawodnik_zawody in db.zawodnik_zawody
                                             where _zawodnik_zawody.id_zawody == competition.id_zawody
                                             select _zawodnik_zawody.id_zawodnik).ToList();

                        checkTeamsRaceResults(id, races, ref teamsAchievements, contestantsIds);
                        competitionResults = CompetitionDataUtility.getCompetitionTeamStandings(races, ref teamsAchievements, contestantsIds);
                        checkTeamsPlaceInCompetition(id, competitionResults, ref teamsAchievements);
                    }
                }
            }
            return teamsAchievements;
        }

        

        static public teamResult getTeamsRaceResult(int teamId, wyscig race, int raceNumber, List<int> contestantsId)
        {
            //skorzystac z competitionDataUtility.getRaceStandings(), znalezc tam beda wyniki w wyscigu + id druzyn
            using (var db = new multiligaEntities())
            {
                var raceStandings = CompetitionDataUtility.getRaceStandings(contestantsId, race, raceNumber);
                var competitionName = db.zawody.Where(z => z.id_zawody == race.id_zawody).SingleOrDefault().nazwa;

                var aggregatedPoints = sumTeamsPoints(raceStandings);
                var place = getTeamsPlaceInRace(aggregatedPoints, teamId);
                teamResult r;
                r.place = place + 1;
                r.competitionName = competitionName;
                r.points = 0;
                r.teamId = teamId;
                r.raceName = ", wyścig numer " + raceNumber.ToString();
                return r;
            }
        }

        static public List<teamResult> sumTeamsPoints(List<result> allResults)
        {
            var aggregatedPoints = new List<teamResult>();
            foreach(var result in allResults)
            {
                foreach(var id in result.teamIds)
                {
                    if (!aggregatedPoints.Any(c => c.teamId == id))
                    {
                        aggregatedPoints.Add(new teamResult { teamId = id, points = result.points,
                            competitionName = result.competitionName, place = 0, raceName = result.raceName });
                    }
                    else
                    {
                        var index = aggregatedPoints.FindIndex(c => c.teamId == id);
                        aggregatedPoints[index] = new teamResult { teamId = id, points = aggregatedPoints[index].points + result.points,
                            competitionName = result.competitionName, place = 0, raceName = result.raceName };
                    }
                }                
            }
            return aggregatedPoints;
        }

        static public int getTeamsPlaceInRace(List<teamResult> results, int teamId)
        {
            var teamsResult = results.Where(r => r.teamId == teamId).SingleOrDefault();
            var place = results.Count(r => r.points > teamsResult.points);
            return place;
        }

        static public void checkTeamsRaceResults(int id, IQueryable<wyscig> races, ref List<teamResult> contestantsAchievements, List<int> contestantsIds)
        {
            int raceNumber = 1;
            var competitionResults = new List<result>();
            foreach (var race in races)
            {
                var r = getTeamsRaceResult(id, race, raceNumber, contestantsIds);
                if (r.place <= 3 && r.place != 0)
                {
                    contestantsAchievements.Add(r);
                }
                ++raceNumber;
            }
        }
        static public void checkTeamsPlaceInCompetition(int teamId, List<teamResult> results, ref List<teamResult> teamsAchievements)
        {
            //skorzystac z competitionDataUtility.getCompStandings(), znalezc tam beda wyniki w calych zawodach + id druzyn
            var teamsCompetitionResult = results.Where(r => r.teamId == teamId).SingleOrDefault();
            var place = results.Count(r => r.points > teamsCompetitionResult.points);

            if(place <= 3)
            {
                teamsCompetitionResult.competitionName += " " + teamsCompetitionResult.points.ToString() + " punktów";
                teamsCompetitionResult.raceName = "";
                teamsCompetitionResult.place = place + 1;
                teamsAchievements.Add(teamsCompetitionResult);
            }
        }
    }
}
