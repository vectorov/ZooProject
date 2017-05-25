using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooProject.Interfaces
{
    interface ICommand
    {
        void Run(params string[] prms);
        string GetCommandName();
    }
}
