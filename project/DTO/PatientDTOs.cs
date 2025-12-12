namespace project.DTO
{
    public class PatientDTOs
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public DateTime DateNaissance { get; set; }

        public List<int> OrdonnanceIds { get; set; } = new List<int>();


    }

}
