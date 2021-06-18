namespace M151_Spital.Models
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