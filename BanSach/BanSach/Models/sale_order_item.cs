namespace BanSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sale_order_item
    {

        [Key]
        public int sale_order_item_id { get; set; }

        public int fk_sale_order { get; set; }

        public int fk_book { get; set; }

        public decimal? sale_order_item_price { get; set; }

        public int? sale_order_item_quantity { get; set; }

        public decimal? sale_order_money { get; set; }

        public virtual book book { get; set; }

        public virtual sale_order sale_order { get; set; }
    }
}
