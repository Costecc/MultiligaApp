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
    
    public partial class organizator
    {
        public int id_organizator { get; set; }
        public int id_ksiegowa { get; set; }
        public int id_kurier { get; set; }
    
        public virtual pracownik pracownik { get; set; }
        public virtual pracownik pracownik1 { get; set; }
        public virtual pracownik pracownik2 { get; set; }
    }
}
