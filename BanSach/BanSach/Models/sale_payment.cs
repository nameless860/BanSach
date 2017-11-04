namespace BanSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sale_payment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sale_payment()
        {
            agency_debt = new HashSet<agency_debt>();
            sale_payment_item = new HashSet<sale_payment_item>();
        }

        [Key]
        public int sale_payment_id { get; set; }

        public int fk_sale_order { get; set; }

        public decimal? sale_payment_money_pay { get; set; }

        public decimal? sale_payment_debt { get; set; }

        public DateTime? sale_payment_time { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<agency_debt> agency_debt { get; set; }

        public virtual sale_order sale_order { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sale_payment_item> sale_payment_item { get; set; }
    }
}
