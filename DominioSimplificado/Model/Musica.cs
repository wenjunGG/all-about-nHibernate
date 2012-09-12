namespace Dominio.Simples.Model
{
    public class Musica
    {
        public virtual int Id { set; get; }
        public virtual string Titulo { set; get; }
        public virtual int Avaliacao { set; get; }
        public virtual int DuracaoSegundos { set; get; }
        public virtual Album Album { set; get; }
    }
}