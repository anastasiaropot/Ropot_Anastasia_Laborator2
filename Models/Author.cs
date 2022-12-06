using System.ComponentModel.DataAnnotations;

namespace Ropot_Anastasia_Lab2.Models
{
    public class Author
    {
        public int ID { get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display (Name ="Author")]
        public string FullName { get; set; }
        public ICollection<Book>? Books { get; set; }

    }
}
