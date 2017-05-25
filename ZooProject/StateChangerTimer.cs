using System;
using System.Threading;

namespace ZooProject
{
    class StateChangerTimer
    {
        private Timer timer;
        private IRepository _repository;
        private object locker = new object();

        public StateChangerTimer(IRepository repository)
        {
            _repository = repository;
            timer = new Timer(ChangeState, null, 0, 5000);
        }

        private void ChangeState(object state)
        {
            lock (locker)
            {
                _repository.ChangeStateForRandomEntity();

                if (_repository.IsAllDead())
                {
                    Console.WriteLine();
                    Console.WriteLine("\nAll animals are dead !\n");
                    Environment.Exit(0);
                }
            }
        }
    }
}
