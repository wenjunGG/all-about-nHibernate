using Dominio.Simples.Model;
using PopulateApp.Controller;
using System;

namespace PopulateApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new DomainSimpleController();            
            controller.Inserir<Pessoa>();
            controller.Inserir<Cidade>();
            controller.Inserir<Estilo>();
            controller.Inserir<Artista>();
            //controller.Inserir<Album>();
            //controller.Inserir<Musica>();

        }
    }
}
