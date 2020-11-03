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
                //TODO szukac zawodnika poprzez zawodnik_zawody i id_druzyny (najpierw trzeba zrobic tworzenie druzyny i zapraszanie)

                return db.zawodnik.Where(z => z.imie_nazwisko.Contains(name)).ToList();


                //return (from _zawodnik in db.zawodnik
                //        join _zawodnik_druzyna in db.zawodnik_druzyna on _zawodnik.id_zawodnik equals _zawodnik_druzyna.id_zawodnik
                //        join _druzyna in db.druzyna on _zawodnik_druzyna.id_druzyna equals _druzyna.id_druzyna                                               
                //        join _zawodnik_zawody in db.zawodnik_zawody on _zawodnik.id_zawodnik equals _zawodnik_zawody.id_zawodnik
                //        join _zawody in db.zawody on _zawodnik_zawody.id_zawody equals _zawody.id_zawody
                //        where _zawodnik.imie_nazwisko.Contains(name) || _druzyna.nazwa.Contains(team) || _zawody.nazwa.Contains(competition)
                //        select _zawodnik
                //        ).ToList();
            }
        }

    }

    
}
