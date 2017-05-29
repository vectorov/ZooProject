using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooProject.Interfaces
{
    interface ICommand
    {
        int ParametersCount { get; set; }
        string CommandName { get; set; }
        string ParamsDescription { get; set; }
        IRepository AnimalsRepository { get; set; }
        void Run(params string[] prms);
    }
}
