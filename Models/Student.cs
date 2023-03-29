using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetRazorsPageEFCore.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }    
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        public bool IsMale { get; set; }
    }
}
