using UnityEngine;
using UnityEngine.Serialization;

namespace Dwarf.ScriptableObjects
{

    [CreateAssetMenu(fileName = "FloatVariable", menuName = "Scriptable Objects/FloatVariable", order = 1)]
    public class FloatVariable : ScriptableObject
    {
        [FormerlySerializedAs("value")]
        public float Value;
    }
}