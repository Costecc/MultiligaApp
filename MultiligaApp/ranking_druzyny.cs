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
    
    public partial class ranking_druzyny
    {
        public int id_druzyna { get; set; }
        public int punkty { get; set; }
    
        public virtual druzyna druzyna { get; set; }
    }
}
