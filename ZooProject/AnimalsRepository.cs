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
            var animal = (AnimalEntity)GetByNickname(nickname);
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
            var animal = (AnimalEntity)GetByNickname(nickname);
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
            var animal = (AnimalEntity)GetByNickname(nickname);
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

        #region LINQ

        private void PutListToConsole(IEnumerable<AnimalEntity> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine($"    {item.ToString()}");
            }
        }
        public void GetGroupedAnimalsByKind()
        {
            var resList = Animals.GroupBy(animal => animal.Kind);
            Console.WriteLine($"Animals grouped by kind : ");
            foreach (var group in resList)
            {
                Console.WriteLine($"Kind: {group.Key}");
                PutListToConsole(group);
            }
        }

        public void GetAnimalsByState(AnimalState state)
        {
            var resList = Animals.Where(animal => animal.State == state);
            Console.WriteLine($"Animals by state {state} : ");
            PutListToConsole(resList);
        }

        public void GetSickTigers()
        {
            var resList = Animals.Where(animal => animal.Kind == AnimalKind.Tiger && animal.State == AnimalState.Sick);
            Console.WriteLine($"All sick tigers : ");
            PutListToConsole(resList);
        }

        public void GetElephantByNickName(string nickname)
        {
            var item = Animals.FirstOrDefault(animal => animal.Kind == AnimalKind.Elephant && animal.Nickname.Contains(nickname));
            Console.WriteLine($"Elephant by nickname {nickname} : ");
            if (item != null)
            {
                Console.WriteLine($"    {item.ToString()}");
            }
            else
            {
                Console.WriteLine($"    not found");
            }
        }

        public void GetAllHungryAnimals()
        {
            var resList = Animals.Where(animal => animal.State == AnimalState.Hungry).Select(x => x.Nickname);
            Console.WriteLine($"All Hungry animals : ");
            foreach (var item in resList)
            {
                Console.WriteLine($"    {item}");
            }
        }

        public void GetMostHealthyAnimals()
        {
            var resList = from a in Animals
                          group a by a.Kind into gr
                          select gr.OrderBy(a => a.Health).Last();
            PutListToConsole(resList);
        }

        public void GetDeadAnimalsCount()
        {
            var resList = Animals.Where(animal => animal.State == AnimalState.Dead).GroupBy(animal => animal.Kind);
            Console.WriteLine($"Dead animals count by kind : ");
            foreach (var group in resList)
            {
                Console.WriteLine($"Kind: {group.Key} - {group.Count()}");
            }
        }

        public void GetAllHealthWolfsBears()
        {
            var resList = Animals
                .Where(animal => animal.Health > 3 && (animal.Kind == AnimalKind.Wolf || animal.Kind == AnimalKind.Bear));
            Console.WriteLine($"All wolfs and bears with health > 3 : ");
            PutListToConsole(resList);
        }

        public void GetMaxMinHealthAnimals()
        {
            Console.WriteLine("Max/min health animals : ");
            var resList = from a in Animals
                           let max = Animals.Max(i => i.Health)
                           let min = Animals.Min(i => i.Health)
                           where a.Health == max || a.Health == min
                           select a;

            PutListToConsole(resList);
        }

        public void GetAverageHealthInZoo()
        {
            var res = Animals.Average(animal => animal.Health);
            Console.WriteLine($"Average health in Zoo : {res}");
        }
        #endregion
    }
}
