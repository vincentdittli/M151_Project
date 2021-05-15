namespace M151_Spital_API.Models
{
    public class Patient : Person
    {
        public Doktor Doktor { get; set; }
        public int DoktorId { get; set; }
    }
}
