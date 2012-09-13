using System;
using System.Collections.Generic;

namespace Dominio.Simples.Model
{
    public class Artista
    {
        public virtual int Id { set; get; }
        public virtual string Nome { set; get; }
        public virtual string Sobrenome { set; get; }
        public virtual DateTime DataNascimento { set; get; }
        public virtual IList<Estilo> Estilos { set; get; }
        public virtual IList<Album> Albuns { set; get; }
        public virtual Cidade Cidade { set; get; }
    }
}
