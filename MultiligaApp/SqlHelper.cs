using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
public struct result
{
    public string competitionName;
    public int place;
};
namespace MultiligaApp
{
   
    class SqlHelper
    {
        static private string currentEmail;

        static public string getCurrentEmail()
        {
            return currentEmail;
        }
        static public void setCurrentEmail(string email)
        {
            currentEmail = email;
        }

        static public uzytkownik getLoggedUser()
        {
            using (var db = new multiligaEntities())
            {
                var currEmail = SqlHelper.getCurrentEmail();
                var currentUser = db.uzytkownik.FirstOrDefault(uz => uz.login == currEmail);

                return currentUser;
            }
        }

        static public zawodnik getLoggedContestant()
        {
            using (var db = new multiligaEntities())
            {
                var currentUser = getLoggedUser();
                var currentContestant = db.zawodnik.FirstOrDefault(zaw => zaw.id_uzytkownik == currentUser.id_uzytkownik);

                return currentContestant;
            }
        }
        static public pracownik getLoggedEmployee()
        {
            using (var db = new multiligaEntities())
            {
                var currentUser = getLoggedUser();
                var currentEmployee = db.pracownik.FirstOrDefault(pr => pr.id_uzytkownik == currentUser.id_uzytkownik);
                return currentEmployee;
            }            
        }       

        static public List<IGrouping<int,zawodnik>> selectContestants(string name, string competition, string discipline, string team )         //IGrouping, bo trzeba zrobić group by, żeby nie wyświetlało tego samego zawodnika kilka razy
        {
            using (var db = new multiligaEntities())
            {
                var contestants = (from _zawodnik in db.zawodnik
                                   join _z_dr in db.zawodnik_druzyna on _zawodnik.id_zawodnik equals _z_dr.id_zawodnik into _z_dr

                                   from _zawodnik_druzyna in _z_dr.DefaultIfEmpty()       //żeby zrobić LEFT JOIN
                                   join _druzyna in db.druzyna on _zawodnik_druzyna.id_druzyna equals _druzyna.id_druzyna into _dr

                                   from _druzyna in _dr.DefaultIfEmpty()
                                   join _zaw_zaw in db.zawodnik_zawody on _zawodnik.id_zawodnik equals _zaw_zaw.id_zawodnik into _zaw_zawody

                                   from _zawodnik_zawody in _zaw_zawody.DefaultIfEmpty()
                                   join _zawody in db.zawody on _zawodnik_zawody.id_zawody equals _zawody.id_zawody into _zaw

                                   from _zawody in _zaw.DefaultIfEmpty()
                                   join _dyscyplina in db.dyscyplina on _zawody.id_dyscyplina equals _dyscyplina.id_dyscyplina into _dys

                                   from _dyscyplina in _dys.DefaultIfEmpty()



                                   where (_zawodnik.imie_nazwisko.Contains(name) && name != "") || (_druzyna.nazwa.Contains(team) && team != "")
                                   || (_zawody.nazwa.Contains(competition) && competition != "") || _dyscyplina.nazwa.Contains(discipline) && discipline != ""

                                   select _zawodnik

                        ).GroupBy(z => z.id_zawodnik).ToList() ;

                return contestants;
            }
        }

        static public void showContestantProfile(ProfileForm profileForm, int userPermissions, int id)
        {
            zawodnik selectedContestant;
            uzytkownik selectedUser;
            using (var db = new multiligaEntities())
            {
                selectedContestant = db.zawodnik.FirstOrDefault(z => z.id_zawodnik == id);
                selectedUser = db.uzytkownik.FirstOrDefault(u => u.id_uzytkownik == selectedContestant.id_uzytkownik);
                        
            }

            profileForm.FillProfileData(selectedContestant.imie_nazwisko, 
                selectedUser.login, 
                getContestantsTeamsNames(id),
                getContestantsCurrentCompetitions(id),
                getContestantsPastCompetitions(id),
                getContestantsAchievements(id, getRacesInCompetitions(getContestantsPastCompetitions(id))), // jesli zawodnik nie ma past comp to nic
                selectedContestant.o_sobie 
                );
        }

        static public List<string> getContestantsTeamsNames(int id)  //zwraca listę nazw drużyn, do których należy zawodnik o podanym id
        {
            List<string> teams;
            using (var db = new multiligaEntities())
            {
                teams = (from _zawodnik_druzyna in db.zawodnik_druzyna
                         join _dr in db.druzyna on _zawodnik_druzyna.id_druzyna equals _dr.id_druzyna into _dr
                         from _druzyna in _dr.DefaultIfEmpty()

                         where (_zawodnik_druzyna.id_zawodnik == id)
                         select _druzyna.nazwa
                         ).ToList();

            }
            return teams;
        }

        static public List<zawody> getContestantsCurrentCompetitions(int id)  //zwraca listę nazw drużyn, do których należy zawodnik o podanym id, parametr onlyPastDates - czy podać jedynie ukończone zawody
        {
            List<zawody> competitions;

            using (var db = new multiligaEntities())
            {
                competitions = (from _zawodnik_zawody in db.zawodnik_zawody
                         join _zaw in db.zawody on _zawodnik_zawody.id_zawody equals _zaw.id_zawody into _zaw
                         from _zawody in _zaw.DefaultIfEmpty()

                         where (_zawodnik_zawody.id_zawodnik == id && _zawody.data_koniec >= DateTime.Now)
                         select _zawody
                         ).ToList();

            }
            return competitions;
        }

        static public List<zawody> getContestantsPastCompetitions(int id)  //zwraca listę nazw drużyn, do których należy zawodnik o podanym id, parametr onlyPastDates - czy podać jedynie ukończone zawody
        {
            List<zawody> competitions;

            using (var db = new multiligaEntities())
            {
                competitions = (from _zawodnik_zawody in db.zawodnik_zawody
                                join _zaw in db.zawody on _zawodnik_zawody.id_zawody equals _zaw.id_zawody into _zaw
                                from _zawody in _zaw.DefaultIfEmpty()

                                where (_zawodnik_zawody.id_zawodnik == id && _zawody.data_koniec < DateTime.Now)
                                select _zawody
                         ).ToList();

            }
            return competitions;
        }

        static public List<wyscig> getRacesInCompetitions(List<zawody> competitions)   
        {
            var races = new List<wyscig>();
            using (var db = new multiligaEntities())
            {
                foreach (var c in competitions)
                {
                    var racesInComp = getRacesInACompetition(c);
                    foreach (var r in racesInComp)
                    {
                        races.Add(r);
                    }                    
                }
            }         
            return races;
        }

        static public List<wyscig> getRacesInACompetition(zawody competition)
        {
            using (var db = new multiligaEntities())
            {
                return (from _wyscig in db.wyscig
                        where _wyscig.id_zawody == competition.id_zawody
                        select _wyscig).ToList();
            }           
        }

        static public List<result> getContestantsAchievements(int id, List<wyscig> races)
        {
            var contestantsAchievements = new List<result>();
            if (getContestantsPastCompetitions(id).Count > 0)
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
                            overallResult = getContestantsPlaceInCompetition(id, previousCompetitionId, sumContestantsTimeInCompetition(id, previousCompetitionId));
                            if (overallResult.place <= 3)
                            {
                                contestantsAchievements.Add(overallResult);
                            }
                            raceNumber = 1;
                        }

                        var result = getContestantsRaceResult(id, r, raceNumber);
                        if (result.place <= 3)
                        {
                            contestantsAchievements.Add(result);
                        }
                        previousCompetitionId = r.id_zawody;
                    }
                    overallResult = getContestantsPlaceInCompetition(id, previousCompetitionId, sumContestantsTimeInCompetition(id, previousCompetitionId));
                    if (overallResult.place <= 3)
                    {
                        contestantsAchievements.Add(overallResult);
                    }
                }
            }
            return contestantsAchievements;
        }

        static public result getContestantsRaceResult(int id, wyscig race, int raceNumber)
        {
            using (var db = new multiligaEntities())
            {
                var time = db.wynik.Where(w => w.id_wyscig == race.id_wyscig && w.id_zawodnik == id).SingleOrDefault().czas;
                var racePlace = (from _wynik in db.wynik
                                 where (_wynik.czas < time && _wynik.id_wyscig == race.id_wyscig)
                                 select _wynik.czas).Count();
                var competitionName = db.zawody.Where(z => z.id_zawody == race.id_zawody).SingleOrDefault().nazwa;

                result r;
                r.place = racePlace + 1;
                r.competitionName = competitionName + ", wyścig numer " + raceNumber.ToString();
                return r;
            }
        }

        static public long sumContestantsTimeInCompetition(int id, int competitionId)
        {
            using (var db = new multiligaEntities())
            {
                return (from _wynik in db.wynik
                        join _wyscig in db.wyscig on _wynik.id_wyscig equals _wyscig.id_wyscig

                        where (_wyscig.id_zawody == competitionId && _wynik.id_zawodnik == id)
                        select _wynik).AsEnumerable().Sum(w => w.czas.Value.Ticks);
            }
        }

        static public result getContestantsPlaceInCompetition(int id, int competitionId, long time)
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
                
                foreach(var c in contestants)
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

                return r;
            }
        }

    }


}
