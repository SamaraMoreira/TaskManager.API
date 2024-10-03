using Microsoft.AspNetCore.Mvc;
using System.Net;
using TaskManager.Application.Dtos;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskApplicationService;

        public TaskController(ITaskService taskApplicationService)
        {
            _taskApplicationService = taskApplicationService;
        }


        /// <summary>
        /// Metodo para obter todos os dados da Task
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces<IEnumerable<TaskEntity>>]
        public IActionResult Get()
        {
            var Tasks = _taskApplicationService.ObterTodasTasks();

            if (Tasks is not null)
                return Ok(Tasks);

            return BadRequest("Não foi possivel obter os dados");
        }

        /// <summary>
        ///  Metodo para obter todos os dados da Task por Id
        /// </summary>
        /// <param name="id"> Parametro que identifica a Task</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Produces<TaskEntity>]
        public IActionResult GetPorId(int id)
        {
            var Tasks = _taskApplicationService.ObterTaskPorId(id);

            if (Tasks is not null)
                return Ok(Tasks);

            return BadRequest("Não foi possivel obter os dados");
        }

        /// <summary>
        /// Metodo para salvar os dados da Task
        /// </summary>
        /// <param name="entity"> Modelo de dados para salvar Task</param>
        /// <returns></returns>
        [HttpPost]
        [Produces<TaskEntity>]
        public IActionResult Post([FromBody] TaskDto entity)
        {
            try
            {
                var Tasks = _taskApplicationService.SalvarDadosTask(entity);

                if (Tasks is not null)
                    return Ok(Tasks);

                return BadRequest("Não foi possivel salvar os dados");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        /// <summary>
        /// Metodo para atualizar os dados da Task 
        /// </summary>
        /// <param name="entity"> Modelo de dados para atualizar Task</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Produces<TaskEntity>]
        public IActionResult Put(int id, [FromBody] TaskDto entity)
        {
            var Tasks = _taskApplicationService.EditarDadosTask(id, entity);

            if (Tasks is not null)
                return Ok(Tasks);

            return BadRequest("Não foi possivel salvar os dados");
        }

        /// <summary>
        ///  Metodo para deletar os dados da Task
        /// </summary>
        /// <param name="id"> Identificador do Task</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Produces<TaskEntity>]
        public IActionResult Delete(int id)
        {
            var Tasks = _taskApplicationService.DeletarDadosTask(id);

            if (Tasks is not null)
                return Ok(Tasks);

            return BadRequest("Não foi possivel deletar os dados");
        }
    }
}
