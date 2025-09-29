using DinoManager.Domain.Commands;
using DinoManager.Domain.Entities;
using DinoManager.Domain.Queries;
using Tools.Cqs.Commands;
using Tools.Cqs.Queries;

namespace DinoManager.Domain.Repositories
{
    public interface IDinoRepository :
        IAsyncCommandHandler<CreateDinoCommand>,
        ICommandHandler<DeleteDinoCommand>,
        ICommandHandler<UpdateDinoCommand>,
        IAsyncQueryHandler<GetAllDinosaureQuery, IEnumerable<Dino>>,
        IQueryHandler<GetDinoByIdQuery, Dino>
    {
    }
}
