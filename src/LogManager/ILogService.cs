using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogManager
{
    public interface ILogService
    {
        Task<int> Create(string type, string message, string userMail, string description,string status);
    }
}
