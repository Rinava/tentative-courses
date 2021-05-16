namespace Exercise.Models
{
    public class Student : Person
    {
        public string IdStudent { get; set; }
        public Level CurrentLevel { get; set; }
        public Modality CurrentModality { get; set; }

        public Student()
        {
        }
    }
}