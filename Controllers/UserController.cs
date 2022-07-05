using Microsoft.AspNetCore.Mvc;
using NotioficationPattern.Notification;

namespace NotioficationPattern.Controllers
{
    public class UserController : ControllerBase
    {
        public UserController(INotificationPattern notificationPattern)
        {
            NotificationPattern = notificationPattern;  
        }

        public INotificationPattern NotificationPattern { get; set; }   

        [Route ("cadastro")]
        [HttpPost]
        public string Cadastro([FromForm] int cpf, [FromForm] string nome, [FromForm] string email)
        {
               var usuário = new Usuario(cpf,nome,email);
               return usuário.Id;
        }
    }
}
