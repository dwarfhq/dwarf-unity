namespace Dwarf.DesignPatterns.State
{
    /// <summary>
    /// Interface for a state in a state machine.
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// Code that runs when we enter the state.
        /// </summary>
        public void Enter() { }

        /// <summary>
        /// Code that runs every frame while we are in the state. Should include a condition to transition to a new state.
        /// </summary>
        public void Update() { }

        /// <summary>
        /// Code that runs when we exit the state.
        /// </summary>
        public void Exit() { }
    }
}