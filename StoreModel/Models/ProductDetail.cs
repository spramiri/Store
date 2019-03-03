using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreModel.Models
{
    [Table("ProductDetails", Schema = "Store")]
    public class ProductDetail
    {
        #region Main Props
        [Key]
        public int ProductDetailId { get; set; }

        [Required(ErrorMessage = "محصول انتخاب نشده است")]
        public int ProductId { get; set; }
        
        [Required]
        [MaxLength(256, ErrorMessage = "طول عنوان بیش از حد مجاز می باشد.")]
        [MinLength(3, ErrorMessage = "طول عنوان نمی تواند کمتر از 3 کاراکتر باشد.")]
        public string Title { get; set; }

        [Required]
        public string Value { get; set; }
        #endregion

        #region navigation props
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        #endregion
    }
}
