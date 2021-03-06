﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
public struct result
{
    public string competitionName, raceName;
    public int place, points, contestantId;
    public List<int> teamIds;
};
namespace MultiligaApp
{
    class ContestantDataUtility : Utility
    {
        static public List<IGrouping<int, zawodnik>> selectContestants(string name, string competition, string discipline, string team)         //IGrouping, bo trzeba zrobić group by, żeby nie wyświetlało tego samego zawodnika kilka razy
        {
            var contestants = (from _zawodnik in db.zawodnik
                               join _zawodnik_druzyna in db.zawodnik_druzyna on _zawodnik.id_zawodnik equals _zawodnik_druzyna.id_zawodnik into _z_dr

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

                    ).GroupBy(z => z.id_zawodnik).ToList();

            return contestants;
        }

        static public void showContestantProfile(ProfileForm profileForm, int id)
        {
            profileForm.setProfileId(id);
            zawodnik selectedContestant;
            uzytkownik selectedUser;

            selectedContestant = db.zawodnik.FirstOrDefault(z => z.id_zawodnik == id);
            selectedUser = db.uzytkownik.FirstOrDefault(u => u.id_uzytkownik == selectedContestant.id_uzytkownik);

            profileForm.FillProfileDataContestant(selectedContestant.imie_nazwisko,
                selectedUser.login,
                getContestantsTeams(id).Select(t => t.nazwa).ToList(),
                getContestantsCurrentCompetitions(id),
                getContestantsPastCompetitions(id),
                getContestantsAchievements(id, getContestantsPastCompetitions(id)), // jesli zawodnik nie ma past comp to nic
                selectedContestant.o_sobie
                );
        }

        static public List<druzyna> getContestantsTeams(int id)  //zwraca listę nazw drużyn, do których należy zawodnik o podanym id
        {
            List<druzyna> teams;

            teams = (from _zawodnik_druzyna in db.zawodnik_druzyna
                     join _dr in db.druzyna on _zawodnik_druzyna.id_druzyna equals _dr.id_druzyna into _dr
                     from _druzyna in _dr.DefaultIfEmpty()

                     where (_zawodnik_druzyna.id_zawodnik == id && _zawodnik_druzyna.zaakceptowane == true)
                     select _druzyna
                     ).ToList();
            return teams;
        }

        static public List<Tuple<druzyna, string>> getContestantsTeamInvitations(int id)   //sprawdzam czy zaproszenia wymagają jeszcze akceptacji
        {
            var invitations = (from _zawodnik_druzyna in db.zawodnik_druzyna
                               join _dr in db.druzyna on _zawodnik_druzyna.id_druzyna equals _dr.id_druzyna into _dr
                               from _druzyna in _dr.DefaultIfEmpty()

                               where (_zawodnik_druzyna.id_zawodnik == id)
                               select new
                               {
                                   _druzyna,
                                   _zawodnik_druzyna.zaakceptowane
                               }
                      ).ToList();

            var invitationWithAction = new List<Tuple<druzyna, string>>();

            foreach (var invitation in invitations)
            {
                var action = "";
                if (invitation.zaakceptowane == false)
                {
                    action = "Akceptuj";
                }
                invitationWithAction.Add(new Tuple<druzyna, string>(invitation._druzyna, action));
            }
            return invitationWithAction;

        }


        static public List<zawody> getContestantsCurrentCompetitions(int id, bool checkInvitations = false)  //zwraca listę nazw drużyn, do których należy zawodnik o podanym id, parametr onlyPastDates - czy podać jedynie ukończone zawody
        {
            List<zawody> competitions;

            if (checkInvitations == false)
            {
                competitions = (from _zawodnik_zawody in db.zawodnik_zawody
                                join _zaw in db.zawody on _zawodnik_zawody.id_zawody equals _zaw.id_zawody into _zaw
                                from _zawody in _zaw.DefaultIfEmpty()

                                where (_zawodnik_zawody.id_zawodnik == id && _zawody.data_koniec >= DateTime.Now && _zawodnik_zawody.zaakceptowane == true)
                                select _zawody).ToList();
            }
            else
            {
                competitions = (from _zawodnik_zawody in db.zawodnik_zawody
                                join _zaw in db.zawody on _zawodnik_zawody.id_zawody equals _zaw.id_zawody into _zaw
                                from _zawody in _zaw.DefaultIfEmpty()

                                where (_zawodnik_zawody.id_zawodnik == id && _zawody.data_koniec >= DateTime.Now)
                                select _zawody).ToList();
            }
            return competitions;
        }

        static public List<zawody> getContestantsPastCompetitions(int id)  //zwraca listę nazw drużyn, do których należy zawodnik o podanym id, parametr onlyPastDates - czy podać jedynie ukończone zawody
        {
            List<zawody> competitions;

            competitions = (from _zawodnik_zawody in db.zawodnik_zawody
                            join _zaw in db.zawody on _zawodnik_zawody.id_zawody equals _zaw.id_zawody into _zaw
                            from _zawody in _zaw.DefaultIfEmpty()

                            where (_zawodnik_zawody.id_zawodnik == id && _zawody.data_koniec < DateTime.Now)
                            select _zawody
                     ).ToList();

            return competitions;
        }

        static public List<wyscig> getRacesInMultipleCompetitions(List<zawody> competitions)
        {
            var races = new List<wyscig>();
            foreach (var c in competitions)
            {
                var racesInComp = getRacesInSingleCompetition(c);
                foreach (var r in racesInComp)
                {
                    races.Add(r);
                }
            }
            return races;
        }

        static public List<wyscig> getRacesInSingleCompetition(zawody competition)
        {
            return (from _wyscig in db.wyscig
                    where _wyscig.id_zawody == competition.id_zawody
                    select _wyscig).ToList();
        }

        static public List<result> getContestantsAchievements(int id, List<zawody> competitions)   //clean this shit
        {
            var contestantsAchievements = new List<result>();

            if (getContestantsPastCompetitions(id).Count > 0)
            {
                foreach (var competition in competitions)
                {
                    var competitionResults = new List<result>();

                    var races = (from _wyscig in db.wyscig
                                 where _wyscig.id_zawody == competition.id_zawody
                                 select _wyscig);

                    var contestantsId = (from _zawodnik_zawody in db.zawodnik_zawody
                                         where _zawodnik_zawody.id_zawody == competition.id_zawody
                                         select _zawodnik_zawody.id_zawodnik).ToList();

                    checkContestantRaceResults(id, races, ref contestantsAchievements);
                    competitionResults = CompetitionDataUtility.getCompetitionStandings(races, ref contestantsAchievements, contestantsId);
                    checkContestantsPlaceInCompetition(id, competitionResults, ref contestantsAchievements);
                }
            }
            return contestantsAchievements;
        }

        static public result getContestantsRaceResult(int id, wyscig race, int raceNumber)
        {
            var raceResult = db.wynik.Where(w => w.id_wyscig == race.id_wyscig && w.id_zawodnik == id).SingleOrDefault();
            var time = TimeSpan.Zero;
            if (raceResult != null)
            {
                time = raceResult.czas.Value;
            }
            var racePlace = (from _wynik in db.wynik
                             where (_wynik.czas < time && _wynik.id_wyscig == race.id_wyscig && _wynik.czas != null && time != null)
                             select _wynik.czas).Count();
            var competitionName = db.zawody.Where(z => z.id_zawody == race.id_zawody).SingleOrDefault().nazwa;

            var teamIds = getContestantsTeams(id).Select(t => t.id_druzyna).ToList();
            result r;
            r.competitionName = competitionName;
            r.points = 0;
            r.contestantId = id;
            r.raceName = ", wyścig numer " + raceNumber.ToString();
            r.teamIds = teamIds;
            if (time != null)
            {
                r.place = racePlace + 1;
                if (racePlace < 10)
                    r.points = 500 - racePlace * 50;
                return r;
            }
            else
            {
                r.place = 0;
                return r;
            }
        }

        static public void checkContestantRaceResults(int id, IQueryable<wyscig> races, ref List<result> contestantsAchievements)
        {
            int raceNumber = 1;
            var competitionResults = new List<result>();
            foreach (var race in races)
            {
                result r = getContestantsRaceResult(id, race, raceNumber);
                if (r.place <= 3 && r.place != 0)
                {
                    contestantsAchievements.Add(r);
                }
                ++raceNumber;
            }
        }

        static public void checkContestantsPlaceInCompetition(int id, List<result> competitionResults, ref List<result> contestantsAchievements)
        {
            var contestantsCompetitionResult = competitionResults.FirstOrDefault(c => c.contestantId == id);

            var contestantsPlace = competitionResults.Count(c => c.points > contestantsCompetitionResult.points);
            if (contestantsPlace <= 3)
            {
                contestantsCompetitionResult.competitionName += " " + contestantsCompetitionResult.points.ToString() + " punktów";
                contestantsCompetitionResult.raceName = "";
                contestantsCompetitionResult.place = contestantsPlace + 1;
                contestantsAchievements.Add(contestantsCompetitionResult);
            }
        }

        static public bool checkIfCaptain(int contestantId)
        {
            return db.druzyna.Any(d => d.id_kapitan == contestantId);
        }
        static public bool isContestantAlreadyInTeam(int contestantId, int teamId)
        {
            return db.zawodnik_druzyna.Any(z => z.id_druzyna == teamId && z.id_zawodnik == contestantId);
        }

        static public void acceptTeamInvitation(int contestantId, int teamId)
        {
            var invitation = db.zawodnik_druzyna.Where(z => z.id_zawodnik == contestantId && z.id_druzyna == teamId).SingleOrDefault();
            invitation.zaakceptowane = true;
            db.SaveChanges();
            MessageBox.Show("Zaakceptowano zaproszenie");
        }
        static public void acceptRaceInvitation(int contestantId, int raceId)
        {
            var raceInvitation = db.zawodnik_wyscig.Where(z => z.id_zawodnik == contestantId && z.id_wyscig == raceId).SingleOrDefault();
            raceInvitation.zaakceptowane = true;
            db.SaveChanges();

            var competition = db.wyscig.Where(w => w.id_wyscig == raceInvitation.id_wyscig).SingleOrDefault();

            acceptCompetitionInvitation(competition.id_zawody, contestantId);
            MessageBox.Show("Zaakceptowano zaproszenie");
        }

        static public void acceptCompetitionInvitation(int competitionId, int contestantId)
        {
            if (!checkIfCompetitionInvitationAccepted(competitionId, contestantId))
            {
                var competitionInvitation = db.zawodnik_zawody.Where(z => z.id_zawodnik == contestantId && z.id_zawody == competitionId).SingleOrDefault();
                competitionInvitation.zaakceptowane = true;
                db.SaveChanges();
            }
        }

        static public bool checkIfCompetitionInvitationAccepted(int competitionId, int contestantId)
        {
            return db.zawodnik_zawody.Any(z => z.id_zawody == competitionId && z.id_zawodnik == contestantId && z.zaakceptowane == true);
        }
    }
}
