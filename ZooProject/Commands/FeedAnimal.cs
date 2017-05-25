using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooProject.Interfaces;

namespace ZooProject.Commands
{
    class FeedAnimal : ICommand
    {
        private string _commandName;
        private IRepository _animalsRepository;

        public FeedAnimal(IRepository repository, string name)
        {
            _animalsRepository = repository;
            _commandName = name;
        }
        public string GetCommandName()
        {
            return _commandName;
        }

        public void Run(params string[] prms)
        {
            _animalsRepository?.FeedAnimal(prms);
        }
    }
}
