using System;
using System.Collections.Generic;

namespace PopulateApp.Repositorio
{
    interface IReositorio<T>
    {
        void Inserir();
        int Contar(Func<T, bool> expression);
        void Deletar(Func<T, bool> expression);
        T Editar(Func<T, bool> expression);
        List<T> Pesquisar(Func<T, bool> expression);
    }
}
