namespace SpeedEat.Dominio.Clientes.Entidades
{
    public class Cliente
    {
        public virtual int Id { get; set; }
        public virtual string? Nome { get; set; }

        protected Cliente() { }

        public Cliente(string nome)
        {
            SetNome(nome);
        }

        public virtual void SetNome(string nome)
        {
            Nome = nome;
        }
    }
}