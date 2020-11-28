﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace MultiligaApp
{
    class CompetitionDataUtility
    {
        static public void createCompetition(int disciplineId, int numberOfRaces, string city, int supervisorId, string name, string schedule, string qualifiers, ref bool successfulOperation)
        {
            using (var db = new multiligaEntities())
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
        }

        static public void deleteCompetition(string name, ref bool successfulOperation)
        {
            if (raceNameTaken(name))
            {
                using (var db = new multiligaEntities())
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
            }
            else
            {
                MessageBox.Show("Nie znaleziono zawodów o podanej nazwie", "Niepowodzenie");
                successfulOperation = false;
            }
        }
        static public void updateCompetition(int disciplineId, int numberOfRaces, string city, int supervisorId, string name, string schedule, string qualifiers, ref bool successfulOperation)
        {
            if (raceNameTaken(name))
            {
                using (var db = new multiligaEntities())
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

        static public bool checkQualifiersPossibility(int numberOfRaces, string info)
        {
            return (numberOfRaces > 1 && info == "kwalifikacje");
        }

        static public bool raceNameTaken(string name)
        {
            using (var db = new multiligaEntities())
            {
                return (db.zawody.Any(z => z.nazwa == name));
            }
        }
    }
}