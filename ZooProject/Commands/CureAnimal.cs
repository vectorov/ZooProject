﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooProject.Interfaces;

namespace ZooProject.Commands
{
    class CureAnimal : ICommand
    {
        public int ParametersCount { get; set; }
        public string CommandName { get; set; }
        public IRepository AnimalsRepository { get; set; }
        public string ParamsDescription { get; set; }


        public CureAnimal(IRepository repository, string name, int parametersCount = 0, string paramsDescription = "")
        {
            AnimalsRepository = repository;
            CommandName = name;
            ParametersCount = parametersCount;
            ParamsDescription = paramsDescription;
        }

        public void Run(params string[] prms)
        {
            AnimalsRepository.CureAnimal(prms);
        }
    }
}
