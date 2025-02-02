//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EfDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class PRODUCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCT()
        {
            this.PRODUCT_SUPPLIER = new HashSet<PRODUCT_SUPPLIER>();
        }
    
        public int PRODUCT_ID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public decimal PRICE { get; set; }
        public int CATEGORY_ID { get; set; }
        public int MANUFACTURER_ID { get; set; }
    
        public virtual CATEGORY CATEGORY { get; set; }
        public virtual MANUFACTURER MANUFACTURER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCT_SUPPLIER> PRODUCT_SUPPLIER { get; set; }
    }
}
