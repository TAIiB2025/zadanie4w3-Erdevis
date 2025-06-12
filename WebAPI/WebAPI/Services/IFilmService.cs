
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IFilmService
    {
        IEnumerable<Film> GetAll();
        Film? GetById(int id);
        Film Add(FilmBody body);
        bool Update(int id, FilmBody body);
        bool Delete(int id);
    }
}
