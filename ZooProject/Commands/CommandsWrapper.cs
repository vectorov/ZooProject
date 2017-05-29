using System;
using System.Collections.Generic;
using ZooProject.Interfaces;

namespace ZooProject.Commands
{
    class CommandsWrapper
    {
        private List<ICommand> Commands;
        private string _parameters;

        public CommandsWrapper(IRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException();
            }

            Commands = new List<ICommand>();
            Commands.Add(new AddAnimal(repository, "Add animal", 2, GetParamDescription(2)));
            Commands.Add(new FeedAnimal(repository, "Feed animal", 1, GetParamDescription(1)));
            Commands.Add(new CureAnimal(repository, "Cure animal", 1, GetParamDescription(1)));
            Commands.Add(new RemoveAnimal(repository, "Remove animal", 1, GetParamDescription(1)));

            Commands.Add(new GetGroupedAnimalsByKind(repository, "Get grouped animals by kind"));
            Commands.Add(new GetAnimalsByState(repository, "Get animals by state", 1, GetParamDescription(1)));
            Commands.Add(new GetSickTigers(repository, "Get sickT tigers"));
            Commands.Add(new GetElephantByNickName(repository, "Get elephant by nickname", 1, GetParamDescription(1)));
            Commands.Add(new GetAllHungryAnimals(repository, "Get all hungry animals"));
            Commands.Add(new GetMostHealthyAnimals(repository, "Get most healthy animals"));
            Commands.Add(new GetDeadAnimalsCount(repository, "Get dead animals count"));
            Commands.Add(new GetAllHealthWolfsBears(repository, "Get all healthy wolfs and bears"));
            Commands.Add(new GetMaxMinHealthAnimals(repository, "Get max/min healthy animals"));
            Commands.Add(new GetAverageHealthInZoo(repository, "Get average health in Zoo"));
        }

        public void PutToConsole()
        {
            var i = 0;
            foreach (var c in Commands)
            {
                Console.WriteLine("{0} - {1}", i++, c.CommandName);
            }
        }

        public void Execute(int numCommand)
        {
            if (numCommand < Commands.Count)
            {
                Commands[numCommand].Run(_parameters.Split(','));
            }
            else
            {
                Console.WriteLine("Wrong number");
            }
        }

        public void GetParameters(int numCommand)
        {
            _parameters = "";
            if (numCommand >= Commands.Count)
            {
                Console.WriteLine("Wrong number");
            }
            var paramCount = Commands[numCommand].ParametersCount;
            if (paramCount > 0)
            {
                var paramsDescription = Commands[numCommand].ParamsDescription;

                Console.Write($"Enter {paramCount} parameters {paramsDescription} : ");

                _parameters = Console.ReadLine();
            }
        }

        private string GetParamDescription(int paramCount)
        {
            var res = "";
            if (paramCount > 0)
            {
                for (int i = 0; i < paramCount; i++)
                {
                    res += $"arg{i},";
                }
                res = res.TrimEnd(',');
            }
            return res;
        }
    }
}
