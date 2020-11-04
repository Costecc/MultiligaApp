using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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

        static public List<zawodnik> selectContestants(string name, string competition, string discipline, string team )
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
                        ).ToList();

                return contestants;
            }
        }

    }

    
}
