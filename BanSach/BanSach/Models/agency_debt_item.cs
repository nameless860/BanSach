namespace BanSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class agency_debt_item
    {
        [Key]
        public int agency_debt_item_id { get; set; }

        public int fk_agency_debt { get; set; }

        public int fk_book { get; set; }

        public int? agency_debt_item_quantity { get; set; }

        public decimal? agency_debt_item_money { get; set; }

        public virtual agency_debt agency_debt { get; set; }

        public virtual book book { get; set; }
    }
}
