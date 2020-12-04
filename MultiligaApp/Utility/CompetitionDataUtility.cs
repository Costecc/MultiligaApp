using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace MultiligaApp
{
    class CompetitionDataUtility : Utility
    {
        static public void createCompetition(int disciplineId, int numberOfRaces, string city, int supervisorId, string name, string schedule, string qualifiers, ref bool successfulOperation, TemplateForm form)
        {
            if (!raceNameTaken(name))   //jeśli nazwa nie jest zajęta
            {
                if (competitionScheduleCheck(Convert.ToInt32(numberOfRaces), schedule))
                {
                    var currentEmployee = LoggedUserUtility.getLoggedEmployee();

                    var competition = new zawody
                    {
                        id_organizator = currentEmployee.id_pracownik,
                        id_dyscyplina = disciplineId,
                        nazwa = name,
                        id_opiekun_zawodow = supervisorId
                    };
                    db.zawody.Add(competition);
                    db.SaveChanges();

                    var dates = new List<DateTime>();
                    dates = getCompetitionDates(schedule);

                    for (int i = 0; i < dates.Count; ++i)
                    {
                        var race = new wyscig { miasto = city, id_zawody = competition.id_zawody, data = dates[i], id_trasa = 1 };
                        db.wyscig.Add(race);
                        db.SaveChanges();

                        if (checkQualifiersPossibility(numberOfRaces, qualifiers) && i == 0)
                        {
                            competition.id_kwalifikacje = race.id_wyscig;
                            db.SaveChanges();
                        }
                    }
                    competition.data_poczatek = dates[0];
                    competition.data_koniec = dates[dates.Count - 1];
                    db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Błąd przy wprowadzaniu harmonogramu wyścigu", "Niepowodzenie");
                    successfulOperation = false;
                }
            }
            else
            {
                MessageBox.Show("Podana nazwa wyścigu jest już zajęta", "Niepowodzenie");
                successfulOperation = false;
            }
        }

        static public void deleteCompetition(string name, ref bool successfulOperation, TemplateForm form)
        {
            if (raceNameTaken(name))
            {
                var competition = db.zawody.FirstOrDefault(z => z.nazwa == name);
                if (LoggedUserUtility.getLoggedEmployee().id_pracownik == competition.id_organizator)   //sprawdzenie uprawnien
                {
                    db.zawody.Remove(competition);
                    db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Nie masz uprawnień do usunięcia tych zawodów", "Niepowodzenie");
                    successfulOperation = false;
                }
            }
            else
            {
                MessageBox.Show("Nie znaleziono zawodów o podanej nazwie", "Niepowodzenie");
                successfulOperation = false;
            }
        }
        static public void updateCompetition(int disciplineId, int numberOfRaces, string city, int supervisorId, string name, string schedule, string qualifiers, ref bool successfulOperation, TemplateForm form)
        {
            if (raceNameTaken(name))
            {
                var competition = db.zawody.FirstOrDefault(z => z.nazwa == name);

                if (LoggedUserUtility.getLoggedEmployee().id_pracownik == competition.id_organizator)   //sprawdzam uprawnienia
                {
                    competition.id_dyscyplina = disciplineId;
                    competition.id_opiekun_zawodow = supervisorId;

                    if (city.Length > 0)   //sprawdzam czy wpisano jakies miasto
                    {
                        var races = db.wyscig.Where(w => w.id_zawody == competition.id_zawody);
                        foreach (var race in races)
                        {
                            race.miasto = city.ToString();
                        }
                        db.SaveChanges();
                    }

                    if (competitionScheduleCheck(numberOfRaces, schedule))  //sprawdzam czy liczba wyscigow pokrywa sie z iloscia dat
                    {
                        var dates = new List<DateTime>();
                        dates = getCompetitionDates(schedule);

                        var races = db.wyscig.Where(w => w.id_zawody == competition.id_zawody);
                        int raceIndex = 0;
                        foreach (var race in races)
                        {
                            if (dates.Count <= raceIndex)
                            {
                                db.wyscig.Remove(race);
                            }
                            else
                            {
                                race.data = dates[raceIndex];
                            }
                            ++raceIndex;
                        }
                        if (dates.Count > races.Count())   //jesli po edycji jest więcej wyścigów niż poprzednio
                        {
                            var cityName = "";
                            if (city.Length == 0)  //sprawdzam czy przy edycji zostało podane nowe miasto
                            {
                                cityName = races.FirstOrDefault<wyscig>().miasto;
                            }
                            else
                            {
                                cityName = city;
                            }

                            for (int i = races.Count(); i < dates.Count; ++i)
                            {
                                var race = new wyscig { miasto = cityName, id_zawody = competition.id_zawody, data = dates[i], id_trasa = 1 };
                                db.wyscig.Add(race);
                            }
                        }

                        //todo qualifiers
                        competition.data_poczatek = dates[0];
                        competition.data_koniec = dates[dates.Count - 1];
                        db.SaveChanges();

                    }

                }
                else
                {
                    MessageBox.Show("Nie masz uprawnień do usunięcia tych zawodów", "Niepowodzenie");
                    successfulOperation = false;
                }
            }
            else
            {
                MessageBox.Show("Nie znaleziono zawodów o podanej nazwie", "Niepowodzenie");
                successfulOperation = false;
            }
        }

        static public bool competitionScheduleCheck(int numberOfRaces, string competitionSchedule)
        {
            int previousSemicolon = 0;
            int numberOfDates = 0;
            bool correctDates = true;
            DateTime dateValue;
            for (int i = 0; i < competitionSchedule.Length; ++i)
            {

                if (competitionSchedule[i] == ';' || i == competitionSchedule.Length - 1)
                {
                    if (previousSemicolon != 0)   //żeby omijać średnik w przypadku wszystkich dat poza pierwszą
                    {
                        ++previousSemicolon;
                    }
                    if (i == competitionSchedule.Length - 1)     //zeby nie ucięło ostatniej cyfry w ostatniej dacie
                    {
                        ++i;
                    }

                    if (!DateTime.TryParse(competitionSchedule.Substring(previousSemicolon, i - previousSemicolon), out dateValue))
                    {
                        correctDates = false;
                        break;
                    }
                    else
                    {
                        ++numberOfDates;
                    }
                    previousSemicolon = i;
                }
            }
            return ((numberOfDates == numberOfRaces) && correctDates);
        }

        static public List<DateTime> getCompetitionDates(string competitionSchedule)
        {
            var dates = new List<DateTime>();
            int previousSemicolon = 0;
            for (int i = 0; i < competitionSchedule.Length; ++i)
            {

                if (competitionSchedule[i] == ';' || i == competitionSchedule.Length - 1)
                {
                    if (previousSemicolon != 0)   //żeby omijać średnik w przypadku wszystkich dat poza pierwszą
                    {
                        ++previousSemicolon;
                    }
                    if (i == competitionSchedule.Length - 1)     //zeby nie ucięło ostatniej cyfry w ostatniej dacie
                    {
                        ++i;
                    }
                    dates.Add(DateTime.Parse(competitionSchedule.Substring(previousSemicolon, i - previousSemicolon)));
                    previousSemicolon = i;
                }
            }
            return dates;
        }

        static public void addToCompetitionStandings(List<result> raceResults, ref List<result> competitionResults)
        {
            foreach (var raceResult in raceResults)  // dodaję punkty do klasyfikacji generalnej
            {
                if (!competitionResults.Any(c => c.contestantId == raceResult.contestantId))
                {
                    competitionResults.Add(raceResult);
                }
                else
                {
                    var index = competitionResults.FindIndex(c => c.contestantId == raceResult.contestantId);
                    competitionResults[index] = new result
                    {
                        contestantId = competitionResults[index].contestantId,
                        points = competitionResults[index].points + raceResult.points,
                        competitionName = raceResult.competitionName,
                        place = 0
                    };
                }
            }
        }

        static public List<result> getCompetitionStandings(IQueryable<wyscig> races, ref List<result> contestantsAchievements, List<int> contestantsId)
        {
            int raceNumber = 1;
            var competitionResults = new List<result>();
            foreach (var race in races)
            {
                var raceResults = getRaceStandings(contestantsId, race, raceNumber);
                addToCompetitionStandings(raceResults, ref competitionResults);
                ++raceNumber;
            }
            return competitionResults;
        }

        static public void addToCompetitionTeamStandings(List<teamResult> raceResults, ref List<teamResult> competitionResults)
        {
            foreach (var raceResult in raceResults)  // dodaję punkty do klasyfikacji generalnej
            {
                if (!competitionResults.Any(c => c.teamId == raceResult.teamId))
                {
                    competitionResults.Add(raceResult);
                }
                else
                {
                    var index = competitionResults.FindIndex(c => c.teamId == raceResult.teamId);
                    competitionResults[index] = new teamResult
                    {
                        teamId = competitionResults[index].teamId,
                        points = competitionResults[index].points + raceResult.points,
                        competitionName = raceResult.competitionName,
                        place = 0
                    };
                }
            }
        }

        static public List<teamResult> getCompetitionTeamStandings(IQueryable<wyscig> races, ref List<teamResult> contestantsAchievements, List<int> contestantsId)
        {
            int raceNumber = 1;
            var competitionResults = new List<teamResult>();
            foreach (var race in races)
            {
                var raceResults = getRaceStandings(contestantsId, race, raceNumber);
                var aggregatedPoints = TeamDataUtility.sumTeamsPoints(raceResults);
                addToCompetitionTeamStandings(aggregatedPoints, ref competitionResults);
                ++raceNumber;
            }
            return competitionResults;
        }

        static public List<result> getRaceStandings(List<int> contestantsId, wyscig race, int raceNumber)
        {
            var raceResults = new List<result>();
            foreach (var contestantId in contestantsId)
            {
                result r = ContestantDataUtility.getContestantsRaceResult(contestantId, race, raceNumber);
                raceResults.Add(r);
            }
            return raceResults;
        }

        static public bool checkQualifiersPossibility(int numberOfRaces, string info)
        {
            return (numberOfRaces > 1 && info == "kwalifikacje");
        }

        static public bool raceNameTaken(string name)
        {
            return (db.zawody.Any(z => z.nazwa == name));
        }
        static public void createCompetitionTeamInvitation(int teamId, int competitionId)
        {
            var teamMembers = db.zawodnik_druzyna.Where(z => z.id_druzyna == teamId).ToList();

            var teamInvite = new druzyna_zawody { id_druzyna = teamId, id_zawody = competitionId, zaakceptowane = false };
            db.druzyna_zawody.Add(teamInvite);
            db.SaveChanges();
            foreach (var member in teamMembers)
            {
                var individualInvite = new zawodnik_zawody { id_zawodnik = member.id_zawodnik, id_zawody = competitionId, zaakceptowane = false };
                db.zawodnik_zawody.Add(individualInvite);
                db.SaveChanges();
            }

        }

        static public List<wyscig> getRacesInCompetition(int competitionId)
        {
            var races = db.wyscig.Where(w => w.id_zawody == competitionId).ToList();
            return races;
        }
        static public List<Tuple<wyscig, string>> getContestantsCompetitionRaces(int contestantsId, int competitionId)   //sprawdzam czy zaproszenia wymagają jeszcze akceptacji
        {
            var invitations = (from _zawodnik_wyscig in db.zawodnik_wyscig
                               join _wyscig in db.wyscig on _zawodnik_wyscig.id_wyscig equals _wyscig.id_wyscig into _w
                               from _wyscig in _w.DefaultIfEmpty()

                               where (_zawodnik_wyscig.id_zawodnik == contestantsId && _wyscig.id_zawody == competitionId)
                               select new
                               {
                                   _wyscig,
                                   _zawodnik_wyscig.zaakceptowane
                               }
                      ).ToList();

            var invitationWithAction = new List<Tuple<wyscig, string>>();

            foreach (var invitation in invitations)
            {
                var action = "";
                if (invitation.zaakceptowane == false)
                {
                    action = "Akceptuj";
                }
                invitationWithAction.Add(new Tuple<wyscig, string>(invitation._wyscig, action));
            }
            return invitationWithAction;
        }

        static public void addRaceTrack(int trackId, int raceId, ref bool successfulOperation)
        {
            if (trackId != 0)
            {
                var race = db.wyscig.Where(w => w.id_wyscig == raceId).SingleOrDefault();
                race.id_trasa = trackId;
                db.SaveChanges();
            }
            else
            {
                MessageBox.Show("Zaznacz jakąś trasę", "Niepowodzenie");
                successfulOperation = false;
            }
        }
        static public List<trasa> getAvailableTracks(int raceId)
        {
            var race = db.wyscig.Where(w => w.id_wyscig == raceId).SingleOrDefault();
            var availableTracks = db.trasa.Where(t => t.miasto == race.miasto).ToList();
            return availableTracks;
        }
    }
}
