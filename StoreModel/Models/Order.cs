using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreModel.Models
{
    [Table("Orders", Schema = "Store")]
    public class Order
    {
        #region Main Props
        [Key]
        public int OrderId { get; set; }

        [Required(ErrorMessage="قیمت کل سفارش مشخص نیست.")]
        public int TotalPrice { get; set; }

        public bool PaymentStatus { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime? PaymentDate { get; set; }
        public int CustomerId { get; set; }
        #endregion

        #region navigation props
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
        #endregion
    }
}
