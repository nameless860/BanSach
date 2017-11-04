namespace BanSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class purchase_order_item
    {
        [Key]
        public int purchase_order_item_id { get; set; }

        public int fk_purchase_order { get; set; }

        public int fk_book { get; set; }

        public decimal? purchase_order_item_price { get; set; }

        public int? purchase_order_item_quantity { get; set; }

        public decimal? purchase_order_money { get; set; }

        public virtual book book { get; set; }

        public virtual purchase_order purchase_order { get; set; }
    }
}
