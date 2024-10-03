using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;
using TaskManager.Domain.Interfaces.Dtos;

namespace TaskManager.Application.Services
{
    public class TaskApplicationService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskApplicationService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public TaskEntity? DeletarDadosTask(int id)
        {
            return _taskRepository.DeletarDados(id);
        }

        public TaskEntity? EditarDadosTask(int id, ITaskDto entity)
        {
            entity.Validate();
            return _taskRepository.EditarDados(new TaskEntity
            {
                Id = id,
                Nome = entity.Nome,
                Descricao = entity.Descricao,
            });
        }

        public TaskEntity? ObterTaskPorId(int id)
        {
            return _taskRepository.ObterPorId(id);
        }

        public IEnumerable<TaskEntity> ObterTodasTasks()
        {
            return _taskRepository.ObterTodos();
        }

        public TaskEntity? SalvarDadosTask(ITaskDto entity)
        {
            entity.Validate();

            return _taskRepository.SalvarDados(new TaskEntity
            {
                Nome = entity.Nome,
                Descricao = entity.Descricao,
            });
        }
    }
}
