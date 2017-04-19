using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReferenceApplication.Models
{
    public class CustomerModel
    {
        [Required]
        [StringLength(10)]
        public string CustomerName { get; set; }

        [Required]
        [RegularExpression("^[A-Z]{3,3}[0-9]{4,4}$")]
        [Key]
        public string CustomerCode { get; set; }
    }
}