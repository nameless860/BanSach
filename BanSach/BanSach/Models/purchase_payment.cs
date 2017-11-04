namespace BanSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class purchase_payment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public purchase_payment()
        {
            purchase_payment_item = new HashSet<purchase_payment_item>();
            supplier_debt = new HashSet<supplier_debt>();
        }

        [Key]
        public int purchase_payment_id { get; set; }

        public int fk_purchase_order { get; set; }

        public decimal? purchase_payment_money_pay { get; set; }

        public decimal? purchase_payment_debt { get; set; }

        public DateTime? purchase_payment_time { get; set; }

        public virtual purchase_order purchase_order { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<purchase_payment_item> purchase_payment_item { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<supplier_debt> supplier_debt { get; set; }
    }
}
