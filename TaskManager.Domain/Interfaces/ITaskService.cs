using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces.Dtos;


namespace TaskManager.Domain.Interfaces
{
    public interface ITaskService
    {
        IEnumerable<TaskEntity> ObterTodasTasks();
        TaskEntity? ObterTaskPorId(int id);
        TaskEntity? SalvarDadosTask(ITaskDto entity);
        TaskEntity? EditarDadosTask(int id,ITaskDto entity);
        TaskEntity? DeletarDadosTask(int id);

    }
}
