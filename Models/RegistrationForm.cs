namespace WAD_WorkAndTravel.Models
{
    public class RegistrationForm
    {
        public int FormID { get; set; }
        public string Plan { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } 
        public string Phone { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string University { get; set; }
        public string FieldOfStudy { get; set; }
        public string YearOfStudy { get; set; }
        public DateOnly GraduationDate { get; set; }
        public DateOnly PreferredStartDate { get; set; }
        public string ProgramDuration { get; set; }
        public string EnglishLevel { get; set; }
        public string WorkExperience { get; set; }
        public string AdditionalInformation { get; set; }

    }
}
