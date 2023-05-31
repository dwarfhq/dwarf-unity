using System;

namespace Dwarf.DesignPatterns.State
{
    /// <summary>
    /// A generic state machine that can be used to control the state of an object of type T.
    /// </summary>
    [Serializable]
    public abstract class StateMachine<T>
    {
        /// <summary>
        /// The current state of the state machine.
        /// </summary>
        public IState<T> CurrentState { get; private set; }

        /// <summary>
        /// Event that is invoked when the state changes.
        /// </summary>
        public event Action<IState<T>> stateChanged;

        /// <summary>
        /// Constructor which invokes the InitializeStates() method from the inheriting class.
        /// </summary>
        /// <param name="controller"></param>
        protected StateMachine(T controller)
        {
            InitializeStates();
        }

        /// <summary>
        /// Initialize the state machine by creating an instance of each possible state.
        /// </summary>
        protected abstract void InitializeStates();

        /// <summary>
        /// Initialize the state machine with a starting state.
        /// </summary>
        /// <param name="state">The starting state</param>
        public void Initialize(IState<T> state)
        {
            CurrentState = state;
            state.Enter();

            // Notify listeners that state has changed
            stateChanged?.Invoke(state);
        }

        /// <summary>
        /// Transition to a new state by calling Exit() on the current state and Enter() on the next state.
        /// </summary>
        /// <param name="nextState">The state to transition to</param>
        public void TransitionTo(IState<T> nextState)
        {
            CurrentState.Exit();
            CurrentState = nextState;
            nextState.Enter();

            // Notify other objects that state has changed
            stateChanged?.Invoke(nextState);
        }

        /// <summary>
        /// Update the current state.
        /// </summary>
        public void Update()
        {
            if (CurrentState != null)
            {
                CurrentState.Update();
            }
        }
    }
}