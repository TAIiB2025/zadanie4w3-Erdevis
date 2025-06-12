namespace WebAPI.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Tytul { get; set; } = null!;
        public string Rezyser { get; set; } = null!;
        public string Gatunek { get; set; } = null!;
        public int Rok_wydania { get; set; }
    }
}
