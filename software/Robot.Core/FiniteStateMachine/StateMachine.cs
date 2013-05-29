using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Robot.Core.FiniteStateMachine
{
    public class StateMachine:IStateMachine
    {
        public IState Current { get; private set; }


        private readonly IList<IState> _states = new List<IState>();
        private readonly IDictionary<Type, IDictionary<Type, Type>> _transitions = new Dictionary<Type, IDictionary<Type, Type>>();//<IState, IDictionary<IStateCommand,IState>

        public void AddState(IState state)
        {
            _states.Add(state);
        }

        public void AddTransition<TFirstState, TStateCommand, TSecondState>()
            where TFirstState : IState
            where TStateCommand : IStateCommand
            where TSecondState : IState
        {
            if(_transitions.ContainsKey(typeof(TFirstState)))
            {
                _transitions[typeof (TFirstState)].Add(typeof (TStateCommand),typeof (TSecondState));
            }
            else
            {
                _transitions.Add(typeof(TFirstState), new Dictionary<Type, Type> { { typeof(TStateCommand), typeof(TSecondState) } });
            }
        }

        public void AddStates(params IState[] states)
        {
            foreach (var state in states)
            {
                AddState(state);
            }
        }

        public void Start<T>() where T : class, IState
        {
            var state = _states.SingleOrDefault(s => s.GetType() == typeof(T));
            if (state != null)
            {
                Current = state;
                Current.Start();
            }
        }

        public void Next<T>() where T : IStateCommand
        {
            var t = _transitions[Current.GetType()][typeof(T)];
            var state = _states.SingleOrDefault(s => s.GetType() == t);
            if(state != null)
            {
                Current.Stop();
                Current = state;
                Current.Start();
            }
        }


        class StateTransition
        {
            public Type StateType { get; private set; }
            public Type CommandType { get; private set; }
            public StateTransition(Type stateType, Type commandType)
            {
                StateType = stateType;
                CommandType = commandType;
            }
        }
    }

    public interface IStateMachine
    {
        IState Current { get; }
        void AddState(IState state);
        void AddTransition<TFirstState, TStateTransition, TSecondState>()
            where TFirstState : IState
            where TStateTransition : IStateCommand
            where TSecondState : IState;
        void Start<T>() 
            where T : class, IState;
        void Next<T>() where T : IStateCommand;
    }

    public interface IState
    {
        string Name { get; }
        void Start();
        void Stop();
    }

    public interface IStateCommand
    {
        
    }

}
