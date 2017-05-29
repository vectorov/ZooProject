﻿using ZooProject.Interfaces;

namespace ZooProject.Commands
{
    class GetMostHealthyAnimals : ICommand
    {
        public int ParametersCount { get; set; }
        public string CommandName { get; set; }
        public IRepository AnimalsRepository { get; set; }
        public string ParamsDescription { get; set; }


        public GetMostHealthyAnimals(IRepository animalsRepository, string name, int parametersCount = 0, string paramsDescription = "")
        {
            AnimalsRepository = animalsRepository;
            CommandName = name;
            ParametersCount = parametersCount;
            ParamsDescription = paramsDescription;
        }

        public void Run(params string[] prms)
        {
            ((AnimalsRepository)AnimalsRepository).GetMostHealthyAnimals();
        }
    }
}
