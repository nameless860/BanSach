namespace BanSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("agency")]
    public partial class agency
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public agency()
        {
            agency_debt = new HashSet<agency_debt>();
            sale_order = new HashSet<sale_order>();
        }

        [Key]
        public int agency_id { get; set; }

        [Required]
        [StringLength(100)]

        [Display(Name = "Tên đại lý")]
        public string agency_name { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Địa chỉ")]
        public string agency_address { get; set; }

        [StringLength(12)]
        [Display(Name = "Số điện thoại")]
        public string agency_phone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<agency_debt> agency_debt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sale_order> sale_order { get; set; }
    }
}
