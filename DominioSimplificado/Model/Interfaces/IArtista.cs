using System;
using System.Collections.Generic;

namespace Dominio.Simples.Model.Interfaces
{
    public interface IArtista : IEntityId
    {
        IList<IAlbum> Albuns { get; set; }
        ICidade Cidade { get; set; }
        DateTime DataNascimento { get; set; }
        IList<IEstilo> Estilos { get; set; }
        string Nome { get; set; }
        string Sobrenome { get; set; }
    }
}
