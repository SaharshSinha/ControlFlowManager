using ControlFlowManager.Declarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ControlFlowManager.Core.Definitions
{
    public class ControlFlowDoer<TControllableStep> : IControlFlowDoer<TControllableStep>
        where TControllableStep : IControlFlowStep
    {
        private IControlFlowStepThener<TControllableStep> _controlFlowStepThener => _controlFlowThener;
        private protected ControlFlowThener<TControllableStep> _controlFlowThener;
        internal protected List<Type> _mostRecentCollectionOfConcurrentSteps;
        internal protected List<List<Type>> _sequenceOfGroupsOfStepsToExecute = new List<List<Type>>();

        public IControlFlowStepThener<TControllableStep> Do<TControllableStepAlias>() 
            where TControllableStepAlias : TControllableStep
        {
            _mostRecentCollectionOfConcurrentSteps
                .Add(typeof(TControllableStepAlias));
            return _controlFlowStepThener;
        }
    }
}
