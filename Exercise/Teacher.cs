namespace Exercise.Models
{
    public class Teacher : Person
    {
        public string IdTeacher { get; set; }

        public Teacher(string _id, string _firstName, string _lastName, Schedule _avariableSchedule, string _idTeacher)
        {
            Id = _id;
            FirstName = _firstName;
            LastName = _lastName;
            AvariableSchedule = _avariableSchedule;
            IdTeacher = _idTeacher;
        }
    }
}