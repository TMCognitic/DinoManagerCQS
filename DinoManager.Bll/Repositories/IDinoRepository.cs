using DinoManager.Bll.Entities;

namespace DinoManager.Bll.Repositories
{
    public interface IDinoRepository
    {
        IEnumerable<Dino> Get();
        Dino? Get(int id);
        bool Create(Dino dino);
        bool Update(int id, Dino dino);
        bool Delete(int id);
    }
}
