using Entities;
using System.Collections.Generic;

namespace Services
{
    public interface IContatoService
    {
        IEnumerable<Contato> ObterTodosContatos();
    }
}
