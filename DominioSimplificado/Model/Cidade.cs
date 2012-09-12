using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Simples.Model
{
    public class Cidade
    {
        public virtual int Id { get; set; }
        public virtual string Nome { set; get; }
        public virtual string Uf { set; get; }
    }
}