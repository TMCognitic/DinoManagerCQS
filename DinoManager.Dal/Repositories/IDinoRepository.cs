using DinoManager.Dal.Entities;

namespace DinoManager.Dal.Repositories
{
    public interface IDinoRepository
    {
        IEnumerable<Dino> Get();
        Dino? Get(int id);
        bool Create(Dino dino);
        bool Update(Dino dino);
        bool Delete(int id);
    }
}
