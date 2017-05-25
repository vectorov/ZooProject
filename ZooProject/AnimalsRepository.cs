using System;
using System.Collections.Generic;
using System.Linq;

namespace ZooProject
{
    class AnimalsRepository : IRepository
    {
        private List<AnimalEntity> Animals;

        public AnimalsRepository()
        {
            Animals = new List<AnimalEntity>();
        }

        public object GetByNickname(string nickname)
        {
            return Animals.FirstOrDefault(animal => animal.Nickname.Equals(nickname));
        }

        public void AddAnimal(params string[] prms)
        {
            if (prms.Length != 2)
            {
                throw new ArgumentException();
            }
            var nickname = prms[0];
            AnimalKind kind;
            if (!Enum.TryParse<AnimalKind>(prms[1], true, out kind))
            {
                Console.WriteLine("\nWrong animal kind!\n");
                return;
            }

            var animal = new AnimalEntity(nickname, kind);
            Animals.Add(animal);

            Console.WriteLine("The animal {0} was add.", animal.Nickname);
        }

        public void FeedAnimal(params string[] prms)
        {
            var nickname = prms[0];
            var animal = (AnimalEntity) GetByNickname(nickname);
            if (animal == null)
            {
                Console.WriteLine("\nThe animal {0} is not found.\n", nickname);
                return;
            }
            else if (animal.State != AnimalState.Dead)
            {
                animal.State = AnimalState.Full;
            }

            Console.WriteLine("\nThe animal {0} was feed.\n", animal.Nickname);
        }
        public void CureAnimal(params string[] prms)
        {
            var nickname = prms[0];
            var animal = (AnimalEntity) GetByNickname(nickname);
            if (animal == null)
            {
                Console.WriteLine("\nThe animal {0} is not found.\n", nickname);
                return;
            }
            else if (animal.State != AnimalState.Dead)
            {
                animal.Health++;
            }

            Console.WriteLine("\nThe animal {0} was feed.\n", animal.Nickname);
        }

        public void RemoveAnimal(params string[] prms)
        {
            var nickname = prms[0];
            var animal = (AnimalEntity) GetByNickname(nickname);
            if (animal == null)
            {
                Console.WriteLine("\nThe animal {0} is not found.\n", nickname);
                return;
            }
            else if (animal.State == AnimalState.Dead)
            {
                Animals.Remove(animal);
                Console.WriteLine("\nThe animal {0} was remove.\n", animal.Nickname);
            }
            else
            {
                Console.WriteLine("\nThe animal {0} has state {1}, not dead.\n", animal.Nickname, animal.State.ToString());
            }
        }

        public void ChangeStateForRandomEntity()
        {
            if (Animals.Count == 0)
            {
                return;
            }

            var random = new Random();
            var num = random.Next(Animals.Count);
            var animal = Animals[num];

            if (animal.State == AnimalState.Dead)
            {
                return;
            }
            else if (animal.State == AnimalState.Sick)
            {
                animal.Health--;
                if (animal.Health == 0)
                {
                    animal.State = AnimalState.Dead;
                }
            }
            else
            {
                animal.State++;
            }
        }

        public bool IsAllDead()
        {
            return Animals.Count > 0 && Animals.Count == Animals.Count(a => a.State == AnimalState.Dead);
        }
    }
}
