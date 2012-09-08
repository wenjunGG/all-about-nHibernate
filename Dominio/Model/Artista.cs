using System.Collections.Generic;

namespace Dominio.Model
{
    public class Artista
    {
        public virtual int Id { set; get; }
        public virtual string NomeArtistico { set; get; }
        public virtual decimal Cache { set; get; }
        public virtual IList<Estilo> Estilos { set; get; }
        public virtual IList<Album> Albuns { set; get; }
    }
}
