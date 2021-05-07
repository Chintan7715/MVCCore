using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BookStore.Enums;
using BookStore.Helper;

namespace BookStore.Models
{
    public class BookModel
    {
        //[DataType(DataType.DateTime)]
        //[DataType(DataType.EmailAddress)]
        //[EmailAddress]
        //public string myFiels { get; set; }        

        public int Id { get; set; }
        [StringLength(100, MinimumLength=3)]
        [Required(ErrorMessage = "Please enter the title of your book")]
        //[MyCustomValidation] //--Custom error message
        public string  Tital { get; set; }
        [Required(ErrorMessage = "Please enter the auhor of your book")]
        public string Author { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public string Category { get; set; }
        [Required(ErrorMessage ="Please choose the language of your book")]
        public int LanguageId { get; set; }

        public string Language { get; set; }
        //[Required(ErrorMessage = "Please choose the MultiLanguage of your book")]
        //public List<string> MultiLanguage { get; set; }
        //[Required(ErrorMessage = "Please choose the LanguageEnum of your book")]
        //public LanguageEnum LanguageEnum { get; set; }
        [Required(ErrorMessage = "Please enter the total pages of your book")]
        [Display(Name = "Total Page")]        
        public int? TotalPage { get; set; }
    }
}
