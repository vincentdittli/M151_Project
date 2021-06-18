namespace M151_Spital.Models
{
    public class Patient : Person
    {
        public Doktor Doktor { get; set; }
        public int DoktorId { get; set; }
    }
}
