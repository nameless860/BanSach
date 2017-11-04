namespace BanSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class supplier_debt_item
    {
        [Key]
        public int supplier_debt_item_id { get; set; }

        public int fk_supplier_debt { get; set; }

        public int fk_book { get; set; }

        public int? supplier_debt_item_quantity { get; set; }

        public decimal? supplier_debt_item_money { get; set; }

        public virtual book book { get; set; }

        public virtual supplier_debt supplier_debt { get; set; }
    }
}
