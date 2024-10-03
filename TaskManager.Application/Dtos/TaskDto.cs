using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Interfaces.Dtos;

namespace TaskManager.Application.Dtos
{
    public class TaskDto : ITaskDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;

        public void Validate()
        {

            var validateResult = new TaskDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }

    internal class TaskDtoValidation : AbstractValidator<TaskDto>
    {
        public TaskDtoValidation()
        {
            RuleFor(x => x.Nome)
                .MinimumLength(5).WithMessage(x => $"O campo {nameof(x.Nome)} deve ter no minimo 5 caracters")
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Nome)} nao pode ser vazio");

            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Descricao)} nao pode ser vazio");

        }

    }
}

