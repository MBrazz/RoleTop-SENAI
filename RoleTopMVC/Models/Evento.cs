namespace RoleTopMVC.Models
{
    public class Evento : Produto {

        public Evento () {

        }

        public Evento (string nome, double preco) {
            this.Nome = nome;
            this.Preco = preco;
        }
    }
}