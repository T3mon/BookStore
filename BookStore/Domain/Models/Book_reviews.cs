using System.Collections.Generic;

namespace Domain.Models
{
    public class Book_reviews
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }

        public IList<Review> Review { get; set; }
        public Book_reviews()
        {
            Review = new List<Review>();
        }

    }
}