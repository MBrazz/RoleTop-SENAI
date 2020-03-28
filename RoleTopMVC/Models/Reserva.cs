using System;
using RoleTopMVC.Enums;

namespace RoleTopMVC.Models
{
    public class Reserva
    {

        public ulong Id {get;set;}
        public Cliente Cliente {get;set;}
        public Evento Evento {get;set;}
        public DateTime DataDaReserva {get;set;}

        public double PrecoTotal {get;set;}

        public uint Status {get;set;}

        public Reserva()
        {
            this.Cliente = new Cliente();
            this.Evento = new Evento();
            this.Id = 0;
            this.Status = (uint) StatusReserva.PENDENTE;
        }
    }
}