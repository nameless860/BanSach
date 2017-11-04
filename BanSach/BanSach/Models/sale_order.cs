namespace BanSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sale_order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sale_order()
        {
            sale_order_item = new HashSet<sale_order_item>();
            sale_payment = new HashSet<sale_payment>();
        }

        [Key]
        public int sale_order_id { get; set; }

        public int fk_agency { get; set; }

        public DateTime? sale_order_created_at { get; set; }

        public decimal? sale_order_total_money { get; set; }

        [StringLength(10)]
        public string sale_order_status { get; set; }

        public virtual agency agency { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sale_order_item> sale_order_item { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sale_payment> sale_payment { get; set; }
    }
}
