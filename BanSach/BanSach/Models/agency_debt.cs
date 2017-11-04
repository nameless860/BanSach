namespace BanSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class agency_debt
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public agency_debt()
        {
            agency_debt_item = new HashSet<agency_debt_item>();
        }

        [Key]
        public int agency_debt_id { get; set; }

        public int fk_agency { get; set; }

        public int fk_sale_payment { get; set; }

        public decimal? agency_debt_total_money { get; set; }

        public DateTime? agency_debt_time { get; set; }

        public virtual agency agency { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<agency_debt_item> agency_debt_item { get; set; }

        public virtual sale_payment sale_payment { get; set; }
    }
}
