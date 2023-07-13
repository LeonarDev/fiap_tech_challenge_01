namespace SpeedEat.Dominio.Categorias.Entidades
{
    public class Categoria
    {
        public virtual int Id { get; set; }
        public virtual string? Nome { get; set; }

        protected Categoria() { }

        public Categoria(string nome)
        {
            SetNome(nome);
        }

        public virtual void SetNome(string nome)
        {
            Nome = nome;
        }
    }
}