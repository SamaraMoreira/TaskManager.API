using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Interfaces.Dtos
{
    public interface ITaskDto
    {
        string Nome { get; set; }
        string Descricao { get; set; }
        void Validate();
    }
}
