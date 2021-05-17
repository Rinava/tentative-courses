namespace Exercise.Models
{
    public class Student : Person
    {
        public string IdStudent { get; set; }
        public Level CurrentLevel { get; set; }
        public Modality CurrentModality { get; set; }

        public Student(string _id, string _firstName, string _lastName, Schedule _avariableSchedule, string _idStudent, Level _currentLevel, Modality _currentModality)
        {
            Id = _id;
            FirstName = _firstName;
            LastName = _lastName;
            AvariableSchedule = _avariableSchedule;
            IdStudent = _idStudent;
            CurrentLevel = _currentLevel;
            CurrentModality = _currentModality;
        }
    }
}