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
    
    public partial class pracownik
    {
        public int id_pracownik { get; set; }
        public string stanowisko { get; set; }
        public string login { get; set; }
        public string haslo { get; set; }
    
        public virtual ksiegowa ksiegowa { get; set; }
        public virtual kurier kurier { get; set; }
        public virtual opiekun_zawodow opiekun_zawodow { get; set; }
        public virtual organizator organizator { get; set; }
    }
}
