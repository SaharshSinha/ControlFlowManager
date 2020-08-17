using HumanBeing.Declarations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HumanBeing.Core.Definitions.DailyTasks
{
    /// <summary>
    /// Captures the daily struggle faced by millions across the planet
    /// </summary>
    public class TheWakeUp : IDailyTask
    {
        private const int MAX_SNOOZE_DURATION_IN_MS = 300;
        private const int SOME_RANDOM_THRESHOLD = 13;
        private bool _unableToWakeUp = true;
        private readonly Random _snoozer = new Random();

        public void Execute()
        {
            Console.WriteLine("Trying to wake up");
            while (_unableToWakeUp)
            {
                Snooze();
            }
            Console.WriteLine("We're up");
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken = default)
        {
            while (_unableToWakeUp && MustWakeUp(cancellationToken))
            {
                await SnoozeAsync();
            }
        }

        private void Snooze()
        {
            Thread.Sleep(TryWakingUp());
        }

        private async Task SnoozeAsync()
        {
            await Task.Delay(TryWakingUp());
        }

        private static bool MustWakeUp(CancellationToken cancellationToken)
        {
            return !cancellationToken.IsCancellationRequested;
        }

        private int TryWakingUp()
        {
            int theWakeupAttemptEffort = _snoozer.Next(MAX_SNOOZE_DURATION_IN_MS);
            if (theWakeupAttemptEffort % SOME_RANDOM_THRESHOLD == 0)
            {
                _unableToWakeUp = false;
            }
            Console.WriteLine("     snooze");
            return theWakeupAttemptEffort;
        }
    }
}
