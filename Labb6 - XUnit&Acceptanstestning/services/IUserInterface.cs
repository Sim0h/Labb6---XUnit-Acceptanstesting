using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb6___XUnit_Acceptanstestning.services
{
    public interface IUserInterface
    {

        void Write(string message);
        void WriteLine(string message);
        string ReadLine();

    }
}
