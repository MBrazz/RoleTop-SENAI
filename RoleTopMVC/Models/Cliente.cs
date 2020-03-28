using System;

namespace RoleTopMVC.Models
{
    public class Cliente
    {
        public string Nome {get;set;}
        public string Email {get;set;}
        public string Senha {get;set;}
        public string ConfirmarSenha {get;set;}
        public uint TipoUsuario {get;set;}

        public Cliente()
        {

        }

        public Cliente(string nome, string email, string senha, string confirmarsenha)
        {
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
            this.ConfirmarSenha = confirmarsenha;
        }
        
    }
}