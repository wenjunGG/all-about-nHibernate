using System;
using System.Collections.Generic;

namespace Dominio.Simples.Model
{
    public class Album
    {
        public virtual int Id { set; get; }
        public virtual Artista Artista { set; get; }
        public virtual string Titulo { set; get; }
        public virtual string Capa { set; get; }
        public virtual int Avaliacao { set; get; }
        public virtual DateTime DataLancamento { set; get; }        
        public virtual IList<Musica> Musicas { set; get; }
    }
}