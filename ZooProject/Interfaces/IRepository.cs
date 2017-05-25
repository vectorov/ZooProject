using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooProject
{
    interface IRepository
    {
        object GetByNickname(string nickname);

        void AddAnimal(params string[] prms);
        void FeedAnimal(params string[] prms);
        void CureAnimal(params string[] prms);
        void RemoveAnimal(params string[] prms);
        void ChangeStateForRandomEntity();
        bool IsAllDead();
    }
}
