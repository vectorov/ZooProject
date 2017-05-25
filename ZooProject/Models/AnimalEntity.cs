using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooProject
{
    class AnimalEntity
    {
        private int _health;

        public int Health { get
            {
                return _health;
            }
            set
            {
                _health = Math.Min((int)Kind, value);
            }
        }
        public AnimalState State { get; set; }
        public string Nickname { get; set; }
        public AnimalKind Kind { get; private set; }

        public AnimalEntity()
        {}

        public AnimalEntity(string nickname, AnimalKind kind)
        {
            Nickname = nickname;
            Kind = kind;
            _health = (int)kind;
            State = AnimalState.Full;
        }
    }
}
