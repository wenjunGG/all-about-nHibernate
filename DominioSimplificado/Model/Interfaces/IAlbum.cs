using System;
using System.Collections.Generic;

namespace Dominio.Simples.Model.Interfaces
{
    public interface IAlbum : IEntityId
    {
        Artista Artista { get; set; }
        int Avaliacao { get; set; }
        string Capa { get; set; }
        DateTime DataLancamento { get; set; }
        IList<Musica> Musicas { get; set; }
        string Titulo { get; set; }
    }
}
