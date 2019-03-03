using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreModel.Models
{
    [Table("OrderProducts", Schema = "Store")]
    public class OrderProduct
    {
        #region main props
        [Key]
        public int OrderProductId { get; set; }

        public int ProductId { get; set; }

        public int OrderId { get; set; }
        #endregion

        #region navigation props

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        #endregion
    }
}
