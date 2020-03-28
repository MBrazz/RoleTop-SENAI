using Microsoft.AspNetCore.Mvc;
using RoleTopMVC.Enums;
using RoleTopMVC.Repositories;
using RoleTopMVC.ViewModels;

namespace RoleTopMVC.Controllers
{
    public class AdministradorController : AbstractController
    {
        ReservaRepository reservaRepository = new ReservaRepository();
        public IActionResult Dashboard()
        {
            var ninguemLogado = string.IsNullOrEmpty(ObterUsuarioTipoSession());
            if (!ninguemLogado && (uint) TiposUsuario.ADMINISTRADOR == uint.Parse(ObterUsuarioTipoSession()))
            {
                var reservas = reservaRepository.ObterTodos();
            DashboardViewModel dashboardViewModel = new DashboardViewModel();

            foreach (var reserva in reservas)
            {
                switch(reserva.Status)
                {
                    case (uint) StatusReserva.APROVADO:
                        dashboardViewModel.ReservasAprovados++;
                    break;
                    case (uint) StatusReserva.REPROVADO:
                        dashboardViewModel.ReservasReprovados++;
                    break;
                    default:
                    dashboardViewModel.ReservasPendentes++;
                    dashboardViewModel.Reservas.Add(reserva);
                    break;
                }
            }
            dashboardViewModel.NomeView = "Dashboard";
            dashboardViewModel.UsuarioEmail = ObterUsuarioSession();

            return View(dashboardViewModel);
            }
            else 
            {
                return View("Erro", new RespostaViewModel()
                {
                    NomeView = "Dashboard",
                    Mensagem= "Você não tem permissão para acessar o Dashboard"
                });
            }
        }
    }
}