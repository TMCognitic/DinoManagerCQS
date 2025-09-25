using DinoManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Cqs.Queries;

namespace DinoManager.Domain.Queries
{
    public class GetAllDinosaureQuery : IQueryDefinition<IEnumerable<Dino>>
    {
    }
}
