using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Interfaces
{
    public interface ITaskRepository
    {
        IEnumerable<TaskEntity> ObterTodos();
        TaskEntity? ObterPorId(int id);
        TaskEntity? SalvarDados(TaskEntity entity);
        TaskEntity? EditarDados(TaskEntity entity);
        TaskEntity? DeletarDados(int id);
    }
}
