using ControlFlowManager.Declarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlFlowManager.Core.Definitions
{
    public class ControlFlowScheduler<TControllableStep> : IControlFlowScheduler<TControllableStep>
        where TControllableStep : IControlFlowStep
    {
        #region PRIVATES
        private readonly Func<IControlFlowStepThener<TControllableStep>> _controlFlowStepGrouperFactory;
        private IControlFlowStepThener<TControllableStep> _controlFlowStepThener;
        private IDictionary<Type, IControlFlowStep> _controllableStepsDictionary;
        #endregion

        public ControlFlowScheduler(
            Func<IControlFlowStepThener<TControllableStep>> controlFlowStepGrouperFactory,
            IEnumerable<TControllableStep> controllableSteps)
        {
            _controlFlowStepGrouperFactory = controlFlowStepGrouperFactory;
            _controllableStepsDictionary = new Dictionary<Type, IControlFlowStep>();
            foreach (var controllableStep in controllableSteps)
            {
                _controllableStepsDictionary.Add(controllableStep.GetType(), controllableStep);
            }
        }

        public IControlFlowStepThener<TControllableStep> Initialize()
        {
            _controlFlowStepThener = _controlFlowStepGrouperFactory.Invoke();
            return _controlFlowStepThener;
        }

        public void Execute()
        { 
            foreach (IReadOnlyCollection<Type> groupsOfStepsToExecute in 
                ((ControlFlowDoer<TControllableStep>)(_controlFlowStepThener))._sequenceOfGroupsOfStepsToExecute)
            {
                if (groupsOfStepsToExecute.Count == 1)
                    ExecuteStep(groupsOfStepsToExecute.First());
                else
                    ExecuteSteps(groupsOfStepsToExecute);
            }
        }

        private void ExecuteStep(Type type)
        {
            IControlFlowStep sequentialStep = _controllableStepsDictionary[type];
            sequentialStep.Execute();
        }

        private void ExecuteSteps(IEnumerable<Type> types)
        {
            Parallel.ForEach
            (
                types, async (type) => 
                {
                    IControlFlowStep aConcurrentStep = _controllableStepsDictionary[type];
                    await aConcurrentStep.ExecuteAsync();
                }
            );
        }

    }
}
