using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Helper
{
    public class MyCustomValidationAttribute : ValidationAttribute
    {
        //public CustomValidationAttribute(string text)
        //{
        //    Text = text;
        //}

        //public string Text { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value!=null)
            {
                string BookName = value.ToString();
                if (BookName.ToLower().Contains("mvc"))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult(ErrorMessage ?? "Please add MVC in the book tital");            
        }
    }
}
