﻿namespace Dominio.Simples.Model
{
    public abstract class Pessoa
    {
        public virtual int Id { set; get; }
        public virtual string Endereco { set; get; }
    }
}