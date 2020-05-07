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
    
    public partial class StockItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StockItem()
        {
            this.FeedPreparings = new HashSet<FeedPreparing>();
            this.Medications = new HashSet<Medication>();
            this.StockAdds = new HashSet<StockAdd>();
        }
    
        public int StockItem_Id { get; set; }
        public int StockType_Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FeedPreparing> FeedPreparings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medication> Medications { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockAdd> StockAdds { get; set; }
        public virtual StockType StockType { get; set; }
    }
}
