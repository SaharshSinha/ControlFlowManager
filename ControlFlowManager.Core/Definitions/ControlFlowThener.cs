using ControlFlowManager.Declarations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControlFlowManager.Core.Definitions
{
    public class ControlFlowThener<TControllableStep> :
        ControlFlowDoer<TControllableStep>, IControlFlowStepThener<TControllableStep>
        where TControllableStep : IControlFlowStep
    {
        public ControlFlowThener() 
        {
            _controlFlowThener = this;
        }

        public IControlFlowDoer<TControllableStep> Then()
        {
            _mostRecentCollectionOfConcurrentSteps = new List<Type>();
            _sequenceOfGroupsOfStepsToExecute.Add(_mostRecentCollectionOfConcurrentSteps);
            return this;
        }
    }
}
