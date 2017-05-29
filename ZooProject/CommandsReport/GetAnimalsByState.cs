using System;
using ZooProject.Interfaces;

namespace ZooProject.Commands
{
    class GetAnimalsByState : ICommand
    {
        public int ParametersCount { get; set; }
        public string CommandName { get; set; }
        public IRepository AnimalsRepository { get; set; }
        public string ParamsDescription { get; set; }


        public GetAnimalsByState(IRepository animalsRepository, string name, int parametersCount = 0, string paramsDescription = "")
        {
            AnimalsRepository = animalsRepository;
            CommandName = name;
            ParametersCount = parametersCount;
            ParamsDescription = paramsDescription;
        }

        public void Run(params string[] prms)
        {
            AnimalState state;
            if (Enum.TryParse<AnimalState>(prms[0], out state))
            {
                ((AnimalsRepository)AnimalsRepository).GetAnimalsByState(state);
            }
        }
    }
}
