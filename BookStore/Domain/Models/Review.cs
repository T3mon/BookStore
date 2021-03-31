using System;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Review
    {
        public int Id { get; set; }
        public Guid? UserId { get; set; }      // внешний ключ
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int? BookId { get; set; }      // внешний ключ
        [ForeignKey("BookId")]
        public Book Book { get; set; }
        public string Headline{ get; set; }
        public string Text{ get; set; }
        public int Score{ get; set; }
        public Review()
        {
            Book = new Book();
            User = new User();
        }
    }
}