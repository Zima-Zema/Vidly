using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class UniqueMovieName : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Movie movie = validationContext.ObjectInstance as Movie;
            if (movie==null)
            {
                return new ValidationResult("Empty Movie");
            }
            if (String.IsNullOrWhiteSpace(movie.Name))
            {
                return new ValidationResult("Movie Name is Required");
            }
            ApplicationDbContext _context = new ApplicationDbContext();
            Movie mov = _context.Movies.FirstOrDefault(m => m.Name == (string)value && m.Id != movie.Id);
            return (mov == null) ? ValidationResult.Success : new ValidationResult("Movie Name exists");
        }
    }
}