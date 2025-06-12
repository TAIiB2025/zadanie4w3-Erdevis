using System.Xml.Linq;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class FilmService : IFilmService
    {
        private static int _idGen = 1;

        
        private readonly List<Film> _films = new()
        {
            new Film { Id = _idGen++, Tytul = "Incepcja", Rezyser = "Christopher Nolan", Gatunek = "Sci-Fi", Rok_wydania = 2010 },
            new Film { Id = _idGen++, Tytul = "Parasite", Rezyser = "Bong Joon-ho", Gatunek = "Dramat", Rok_wydania = 2019 },
            new Film { Id = _idGen++, Tytul = "Skazani na Shawshank", Rezyser = "Frank Darabont", Gatunek = "Dramat", Rok_wydania = 1994 },
            new Film { Id = _idGen++, Tytul = "Matrix", Rezyser = "Lana i Lilly Wachowski", Gatunek = "Sci-Fi", Rok_wydania = 1999 },
            new Film { Id = _idGen++, Tytul = "Gladiator", Rezyser = "Ridley Scott", Gatunek = "Historyczny", Rok_wydania = 2000 }
        };

        public IEnumerable<Film> GetAll() => _films;

        public Film? GetById(int id) =>
            _films.FirstOrDefault(f => f.Id == id);

        public Film Add(FilmBody body)
        {
            var film = new Film
            {
                Id = _idGen++,
                Tytul = body.Tytul,
                Rezyser = body.Rezyser,
                Gatunek = body.Gatunek,
                Rok_wydania = body.Rok_wydania
            };
            _films.Add(film);
            return film;
        }

        public bool Update(int id, FilmBody body)
        {
            var film = GetById(id);
            if (film is null) return false;

            film.Tytul = body.Tytul;
            film.Rezyser = body.Rezyser;
            film.Gatunek = body.Gatunek;
            film.Rok_wydania = body.Rok_wydania;
            return true;
        }

        public bool Delete(int id)
        {
            var film = GetById(id);
            if (film is null) return false;
            _films.Remove(film);
            return true;
        }
    }
}
