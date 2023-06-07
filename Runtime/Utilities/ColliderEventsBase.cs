using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Dwarf.Utilities
{
    /// <summary>
    /// UnityEvent type with a single <example>Collision2D</example> parameter
    /// </summary>
    [System.Serializable]
    public class CollisionEvent2D : UnityEvent<Collision2D> { }

    /// <summary>
    /// UnityEvent type with a single <example>Collider2D</example> parameter
    /// </summary>
    [System.Serializable]
    public class TriggerEvent2D : UnityEvent<Collider2D> { }

    /// <summary>
    /// UnityEvent type with a single <example>Collision</example> parameter
    /// </summary>
    [System.Serializable]
    public class CollisionEvent3D : UnityEvent<Collision> { }

    /// <summary>
    /// UnityEvent type with a single <example>Collider</example> parameter
    /// </summary>
    [System.Serializable]
    public class TriggerEvent3D : UnityEvent<Collider> { }

    /// <summary>
    /// Base class for ColliderEvents2D and ColliderEvents3D
    /// </summary>
    public abstract class ColliderEventsBase : MonoBehaviour
    {
        [Header("Filter")]
        [SerializeField]
        [Tooltip("Only GameObjects with these tags will trigger the collider events"), FormerlySerializedAs("tags ")]
        List<string> _tags = new();
        [SerializeField, FormerlySerializedAs("Conditions")]
        ConditionBase[] _conditions;

        /// <summary>
        /// Check whether a given tag is allowed through the filter
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <returns><example>true</example>, if the tag is allowed. Otherwise, <example>false</example></returns>
        protected bool IsFiltered(string tag)
        {
            for (int i = 0; i < _conditions.Length; i++)
            {
                if (!_conditions[i].IsSatisfied)
                {
                    return false;
                }
            }

            return _tags.Count == 0 || _tags.Contains(tag);
        }
    }
}
