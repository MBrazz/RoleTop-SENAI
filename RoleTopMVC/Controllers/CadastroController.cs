using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Enums;
using RoleTopMVC.Models;
using RoleTopMVC.Repositories;
using RoleTopMVC.ViewModels;

namespace RoleTopMVC.Controllers
{
    public class CadastroController : AbstractController {

        ClienteRepository clienteRepository = new ClienteRepository ();
        public IActionResult Index () {
            return View (new BaseViewModel () {
                NomeView = "Cadastro",
                UsuarioEmail = ObterUsuarioSession(),
                UsuarioNome = ObterUsuarioNomeSession()
            }
            );
        }

        public IActionResult CadastrarCliente (IFormCollection form) {
            Cliente cliente = new Cliente();
            ViewData["Action"] = "Cadastro";
            try {
                cliente = new Cliente (form["nome"], form["email"], form["senha"], form["confirmarsenha"]);

                cliente.TipoUsuario = (uint) TiposUsuario.CLIENTE;

                clienteRepository.Inserir (cliente);

                return View ("Sucesso", new RespostaViewModel()
                {
                    NomeView = "Cadastro",
                    UsuarioEmail = ObterUsuarioSession(),
                    UsuarioNome = ObterUsuarioNomeSession()
                });

            } catch (Exception e) {
                System.Console.WriteLine (e.StackTrace);
                return View ("Erro", new RespostaViewModel()
                {
                    NomeView = "Cadastro",
                    Mensagem = $"{cliente.Nome} seu cadastro foi concluído!"
                });
            }
        }
    }
}