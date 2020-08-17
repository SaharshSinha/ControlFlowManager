using System;
using System.Threading;
using System.Threading.Tasks;

namespace HumanBeing.Core.Definitions
{
    public  abstract class TaskBase 
    {
        private bool _thisIsAVisciousCircle = false;
        public virtual void Execute()
        {
            IsThisAVisciousCircle();
            ExecuteAsync()
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();
        }

        public async virtual Task ExecuteAsync(CancellationToken cancellationToken = default)
        {
            IsThisAVisciousCircle();
            await Task.Run(() => Execute());
        }

        private void IsThisAVisciousCircle()
        {
            if (_thisIsAVisciousCircle)
                throw new NotImplementedException("This path you have taken will end in a stack overflow exception");
            _thisIsAVisciousCircle = true;
        }
    }
}
