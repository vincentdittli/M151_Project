namespace M151_Spital_API.Models
{
    public class Anfrage
    {
        public int Id { get; set; }
        public Doktor Doktor { get; set; }
        public int DoktorId { get; set; }   
        public Patient Patient { get; set; }
        public int PatientId { get; set; }

    }
}
