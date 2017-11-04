namespace BanSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class purchase_order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public purchase_order()
        {
            purchase_order_item = new HashSet<purchase_order_item>();
            purchase_payment = new HashSet<purchase_payment>();
        }

        [Key]
        public int purchase_order_id { get; set; }

        public int fk_supplier { get; set; }

        public DateTime? purchase_order_created_at { get; set; }

        public decimal? purchase_order_total_money { get; set; }

        [StringLength(10)]
        public string purchase_order_status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<purchase_order_item> purchase_order_item { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<purchase_payment> purchase_payment { get; set; }

        public virtual supplier supplier { get; set; }
    }
}
