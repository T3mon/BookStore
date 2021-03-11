﻿namespace Domain.Models
{
    public class Review
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Headline{ get; set; }
        public string Text{ get; set; }
        public int Score{ get; set; }
        public Review()
        {
            User = new User();
        }
    }
}