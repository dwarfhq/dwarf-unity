using UnityEngine;

namespace Dwarf.Utilities
{
    public abstract class ConditionBase : MonoBehaviour, ICondition
    {
        public abstract bool IsSatisfied { get; }
    }
}