using System.ComponentModel.DataAnnotations;

namespace BookWebAPI.Entities
{
    public class Author
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }
        public User User { get; set; }

        public ICollection<Book> Books {get; set;}
    }
}
