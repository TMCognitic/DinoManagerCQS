using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.Cqs.Commands;

namespace DinoManager.Domain.Commands
{
    public class DeleteDinoCommand : ICommandDefinition
    {
        public int Id { get; }
        public DeleteDinoCommand(int id)
        {
            Id = id;
        }
    }
}
