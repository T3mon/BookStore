namespace BLL.ModelsDto
{
    public class ReviewDto
    {
        public UserDto User { get; set; }
        public BookDto Book { get; set; }
        public string Headline { get; set; }
        public string Text { get; set; }
        public int Score { get; set; }
        public ReviewDto()
        {
            Book = new BookDto();
            User = new UserDto();
        }
    }
}