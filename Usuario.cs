using NotioficationPattern.Notification
namespace NotioficationPattern
{
    public class Usuario
    {
        public Usuario(int cpf, string nome, string email)
        {
            Id = Guid.NewGuid().ToString();
            Cpf = cpf;
            Nome = nome;
            Email = email;
            Validations();
        }

        public string Id { get; set; }
        public int Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }


        public void Validations()
        {

            if (Cpf == 0)
                AddError();

            if (Nome == null)
                Errors.AddNotification("O nome é obrigatório");

            if (Errors.ListMessage.Count > 0)
                throw new CustomException();
        }
    }
}
