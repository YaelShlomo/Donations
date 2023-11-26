using Donations.Common.Email.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donations.Common.Email.Services
{
    public interface IEmailService
    {
        void SendEmail(EmailDto reques);
    }
}
