namespace WebApplication1.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }  // Add this property
        public DateTime BirthDate { get; set; }  // Add this property
    }
}
