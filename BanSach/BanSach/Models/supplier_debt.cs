namespace BanSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class supplier_debt
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public supplier_debt()
        {
            supplier_debt_item = new HashSet<supplier_debt_item>();
        }

        [Key]
        public int supplier_debt_id { get; set; }

        public int fk_supplier { get; set; }

        public int fk_purchase_payment { get; set; }

        public decimal? supplier_debt_total_money { get; set; }

        public DateTime? supplier_debt_time { get; set; }

        public virtual purchase_payment purchase_payment { get; set; }

        public virtual supplier supplier { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<supplier_debt_item> supplier_debt_item { get; set; }
    }
}
