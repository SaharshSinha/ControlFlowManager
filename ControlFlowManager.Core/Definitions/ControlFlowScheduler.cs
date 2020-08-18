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
        private readonly Func<IControlFlowStepThenDoer<TControllableStep>> _controlFlowStepGrouperFactory;
        private IControlFlowStepThenDoer<TControllableStep> _controlFlowStepThenDoer;
        private IDictionary<Type, IControlFlowStep> _controllableStepsDictionary;
        #endregion

        public ControlFlowScheduler(
            Func<IControlFlowStepThenDoer<TControllableStep>> controlFlowStepGrouperFactory,
            IEnumerable<TControllableStep> controllableSteps)
        {
            _controlFlowStepGrouperFactory = controlFlowStepGrouperFactory;
            _controllableStepsDictionary = new Dictionary<Type, IControlFlowStep>();
            foreach (var controllableStep in controllableSteps)
            {
                _controllableStepsDictionary.Add(controllableStep.GetType(), controllableStep);
            }
        }

        public IControlFlowStepThenDoer<TControllableStep> Initialize()
        {
            _controlFlowStepThenDoer = _controlFlowStepGrouperFactory.Invoke();
            return _controlFlowStepThenDoer;
        }

        public void Execute()
        { 
            foreach (IReadOnlyCollection<Type> groupsOfStepsToExecute in 
                ((ControlFlowDoer<TControllableStep>)(_controlFlowStepThenDoer))._sequenceOfGroupsOfStepsToExecute)
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
