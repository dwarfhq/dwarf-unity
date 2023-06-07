namespace Dwarf.Utilities
{
    public interface ICondition
    {
        /// <summary>
        /// Boolean indicating whether the implemented selection condition is satisfied
        /// </summary>
        public bool IsSatisfied { get; }
    }
}