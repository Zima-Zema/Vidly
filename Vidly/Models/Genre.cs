using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="*")][MaxLength(50,ErrorMessage ="Genre Should be less than 50")]
        public string Name { get; set; }
       

    }
}