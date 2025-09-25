using DalDino = DinoManager.Dal.Entities.Dino;
using DinoManager.Bll.Entities;
using DinoManager.Bll.Mappers;
using DinoManager.Bll.Repositories;

using IDalDinoRepository = DinoManager.Dal.Repositories.IDinoRepository;

namespace DinoManager.Bll.Services
{
    public class DinoService : IDinoRepository
    {
        private readonly IDalDinoRepository _dinoRepository;

        public DinoService(IDalDinoRepository dinoRepository)
        {
            _dinoRepository = dinoRepository;
        }

        public IEnumerable<Dino> Get()
        {
            return _dinoRepository.Get().Select(d => d.ToBll());
        }

        public Dino? Get(int id)
        {
            return _dinoRepository.Get(id)?.ToBll();
        }

        public bool Create(Dino dino)
        {
            return _dinoRepository.Create(dino.ToDal());
        }

        public bool Update(int id, Dino dino)
        {
            DalDino dalDino = dino.ToDal();
            dalDino.Id = id;

            return _dinoRepository.Update(dalDino);
        }

        public bool Delete(int id)
        {
            return _dinoRepository.Delete(id);
        }
    }
}
