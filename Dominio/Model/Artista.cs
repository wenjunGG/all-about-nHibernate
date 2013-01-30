using Dominio.Model.Interfaces;
using System;
using System.Collections.Generic;

namespace Dominio.Model
{
    public class Artista : IArtista
    {
        public virtual int Id { set; get; }
        public virtual string Nome { set; get; }
        public virtual string Sobrenome { set; get; }
        public virtual DateTime DataNascimento { set; get; }
        public virtual IList<IEstilo> Estilos { set; get; }
        public virtual IList<IAlbum> Albuns { set; get; }
        public virtual ICidade Cidade { set; get; }
    }
}
