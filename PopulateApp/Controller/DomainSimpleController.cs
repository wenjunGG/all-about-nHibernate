using Dominio.Model;
using PopulateApp.Repositorio;
using PopulateApp.Repositorio.Simples;

namespace PopulateApp.Controller
{
    public class DomainSimpleController
    {
        private EstiloRepositorio _repoEsitlo;

        public void Inserir<T>(){
            if (typeof(T) == typeof(Estilo))
                InserirEstilo();
        }

        private void InitRepositorio<T>() {
            if (typeof(T) == typeof(Estilo) && _repoEsitlo == null)
                _repoEsitlo = new EstiloRepositorio();
        }

        private void InserirEstilo() {
            InitRepositorio<Estilo>();
            _repoEsitlo.Inserir();
        }
    }
}