//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ranch_Max
{
    using System;
    using System.Collections.Generic;
    
    public partial class AnimalSale
    {
        public int AnimalSale_Id { get; set; }
        public int Animal_Id { get; set; }
        public Nullable<int> Amount { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string BuyerName { get; set; }
        public string CNIC { get; set; }
    
        public virtual Animal Animal { get; set; }
    }
}
