using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data.AppData;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationContext _context;

        public TaskRepository(ApplicationContext context)
        {
            _context = context;
        }
        public TaskEntity? DeletarDados(int id)
        {
            var entity = _context.Task.Find(id);

            if (entity is not null)
            {
                _context.Task.Remove(entity);
                _context.SaveChanges();

                return entity;
            }

            return null;
        }

        public TaskEntity? EditarDados(TaskEntity entity)
        {
            var Task = _context.Task.Find(entity.Id);

            if (Task is not null)
            {
                Task.Nome = entity.Nome;
                Task.Descricao = entity.Descricao;

                _context.Task.Update(Task);
                _context.SaveChanges();

                return entity;
            }

            return null;
        }

        public TaskEntity? ObterPorId(int id)
        {
            var Task = _context.Task.Find(id);

            if (Task is not null)
            {
                return Task;
            }

            return null;
        }

        public IEnumerable<TaskEntity> ObterTodos()
        {
            var Tasks = _context.Task.ToList();

            return Tasks;
        }

        public TaskEntity? SalvarDados(TaskEntity entity)
        {
            _context.Task.Add(entity);
            _context.SaveChanges();

            return entity;
        }
    }
}
