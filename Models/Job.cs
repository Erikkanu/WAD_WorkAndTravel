namespace WAD_WorkAndTravel.Models
{
    public class Job
    {
        public int JobID { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }  
        public string Description { get; set; }
        public string Location { get; set; }
        public string State { get; set; }  
        public decimal Wage { get; set; }  
        public string Hours { get; set; } 
        public string Category { get; set; }
        public bool Housing { get; set; }
        public DateOnly StartDate { get; set; }  
        public DateOnly EndDate { get; set; }  
        public string LogoPath { get; set; }
    }

}
