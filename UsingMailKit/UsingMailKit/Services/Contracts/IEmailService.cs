using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingMailKit.Domain;

namespace UsingMailKit.Services.Contracts
{
    public interface IEmailService
    {
        void Send(EmailMessage message);        
    }
}
