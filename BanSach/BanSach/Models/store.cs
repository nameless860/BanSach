namespace BanSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("store")]
    public partial class store
    {
        [Key]
        public int store_id { get; set; }

        public int fk_book { get; set; }

        public int? store_quantity { get; set; }

        public decimal? store_seling_price { get; set; }

        public decimal? store_purchase_price { get; set; }

        public DateTime? store_time { get; set; }

        public virtual book book { get; set; }
    }
}
