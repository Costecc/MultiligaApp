//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MultiligaApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class zawodnik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public zawodnik()
        {
            this.druzyna = new HashSet<druzyna>();
            this.wplata = new HashSet<wplata>();
            this.wynik = new HashSet<wynik>();
            this.zawodnik_druzyna = new HashSet<zawodnik_druzyna>();
            this.zawodnik_wyscig = new HashSet<zawodnik_wyscig>();
            this.zawodnik_zawody = new HashSet<zawodnik_zawody>();
        }
    
        public int id_zawodnik { get; set; }
        public int id_uzytkownik { get; set; }
        public Nullable<int> wiek { get; set; }
        public Nullable<int> wzrost { get; set; }
        public Nullable<int> waga { get; set; }
        public string o_sobie { get; set; }
        public Nullable<short> publiczne { get; set; }
        public string imie_nazwisko { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<druzyna> druzyna { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wplata> wplata { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<wynik> wynik { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<zawodnik_druzyna> zawodnik_druzyna { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<zawodnik_wyscig> zawodnik_wyscig { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<zawodnik_zawody> zawodnik_zawody { get; set; }
    }
}
