using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Models
{
    public class PhoneBookModel
    {
        public int Index { get; set; }
        public int ID { get; set; }
        [Required(ErrorMessage ="Please, Enter a name")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{5})$", ErrorMessage = "Please, Enter a valid phone number")]
        public string FirstNumber { get; set; }
        public string SecondNumber { get; set; }
        public int DeleteStatus { get; set; }
    }
}
