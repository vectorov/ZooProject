using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooProject.Commands;

namespace ZooProject
{
    class MainController
    {
        public MainController()
        {
            Start();
        }

        public void Start()
        {
            var repository = new AnimalsRepository();

            new StateChangerTimer(repository);

            CommandsWrapper commandsWrapper = new CommandsWrapper(repository);
            while (true)
            {
                Console.WriteLine("=====================");
                Console.WriteLine("Available сommands : ");
                commandsWrapper.PutToConsole();
                Console.Write("Choose command : ");
                var chooseCommand = Console.ReadLine();
                int numCommand = -1;

                if (int.TryParse(chooseCommand, out numCommand))
                {
                    commandsWrapper.GetParameters();
                    commandsWrapper.Execute(numCommand);
                }
            }
        }
    }
}
