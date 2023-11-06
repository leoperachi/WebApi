using Microsoft.AspNetCore.Mvc;
using System.Transactions;
using WebApi.Models;

namespace WebApi.Base
{
    public abstract class BaseController<T> : ControllerBase
    {
        public abstract Task<ActionResult<IEnumerable<T>>> Listar();
        public abstract Task<ActionResult<T>> Buscar(int id);
        public abstract Task<ActionResult<T>> Salvar(Tarefa tarefa);
        public abstract Task<IActionResult> Deletar(int id);
        public abstract Task<ActionResult<T>> Alterar(Tarefa tarefa);

    }
}
