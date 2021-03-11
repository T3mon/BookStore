using System.Collections.Generic;

namespace Domain.Models
{
    public class Reviews
    {
        public int Id { get; set; }
        public IList<Review> Review { get; set; }
        public Reviews()
        {
            Review = new List<Review>();
        }

    }
}