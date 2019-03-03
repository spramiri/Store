﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreModel.Models
{
    [Table("Customers", Schema = "Store")]
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
    }
}
