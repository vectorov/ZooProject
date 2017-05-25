using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooProject.Interfaces;

namespace ZooProject.Commands
{
    class AddAnimal : ICommand
    {
        private string _commandName;
        private IRepository _animalsRepository;

        public AddAnimal(IRepository animalsRepository, string name)
        {
            _animalsRepository = animalsRepository;
            _commandName = name;
        }
        public string GetCommandName()
        {
            return _commandName;
        }

        public void Run(params string[] prms)
        {
            _animalsRepository.AddAnimal(prms);
        }
    }
}
