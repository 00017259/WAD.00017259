namespace WAD._00017259.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
