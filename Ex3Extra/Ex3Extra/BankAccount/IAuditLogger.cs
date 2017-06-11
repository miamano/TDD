using System.Collections.Generic;

namespace BankAccount
{
    public interface IAuditLogger
    {
        void AddMessage(string message);
        List<string> GetLog();
    }
}