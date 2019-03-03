using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StoreModel.Models
{
    [Table("Products", Schema="Store")]
    public class Product
    {
        #region Main Props
        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(256,ErrorMessage = "طول عنوان بیش از حد مجاز می باشد.")]
        [MinLength(3, ErrorMessage = "طول عنوان نمی تواند کمتر از 3 کاراکتر باشد.")]
        public string Title { get; set; }

        [Required]
        [Range(0,int.MaxValue,ErrorMessage = "مقدار وارد شده مجاز نمی باشد.")]
        public int Price { get; set; }

        [MaxLength(2048, ErrorMessage = "طول توضیحات بیش از حد مجاز می باشد.")]
        public string Description { get; set; }
        #endregion

        #region navigation props
        [ForeignKey("ProductId")]
        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
        #endregion
    }
}
