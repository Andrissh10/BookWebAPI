using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWebAPI.Entities
{
    public class Book
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Title { get; set; } = string.Empty;

        public DateTime PublishedDate { get; set; }
        public int AuthorId { get; set; }

        public Author Author { get; set; }
    }
}
