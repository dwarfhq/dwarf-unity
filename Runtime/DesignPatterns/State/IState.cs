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
        void Enter() { }

        /// <summary>
        /// Code that runs every frame while we are in the state. Should include a condition to transition to a new state.
        /// </summary>
        void Update() { }

        /// <summary>
        /// Code that runs when we exit the state.
        /// </summary>
        void Exit() { }
    }
}