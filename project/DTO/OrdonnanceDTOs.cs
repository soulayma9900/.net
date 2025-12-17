namespace project.DTO
{
    public class OrdonnanceDTOs
    {
      //  public int Id { get; set; }
        public DateTime Date { get; set; }

        public int PatientId { get; set; }
        public int PharmacienId { get; set; }

        // Liste des médicaments liés à l’ordonnance
        public List<int> MedicamentIds { get; set; } = new();
    }
}
