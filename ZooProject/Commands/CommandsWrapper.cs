using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Commands.Add(new AddAnimal(repository, "Add animal"));
            Commands.Add(new FeedAnimal(repository, "Feed animal"));
            Commands.Add(new CureAnimal(repository, "Cure animal"));
            Commands.Add(new RemoveAnimal(repository, "Remove animal"));
        }

        public void PutToConsole()
        {
            var i = 0;
            foreach (var c in Commands)
            {
                Console.WriteLine("{0} - {1}", i++, c.GetCommandName());
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

        public void GetParameters()
        {
            Console.Write("Enter parameters : ");
            _parameters = Console.ReadLine();
        }
    }
}
