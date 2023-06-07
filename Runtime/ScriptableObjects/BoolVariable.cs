using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Serialization;

namespace Dwarf.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BoolVariable", menuName = "Scriptable Objects/BoolVariable", order = 1)]
    [MovedFrom("Assembly-CSharp")]
    public class BoolVariable : ScriptableObject
    {
        [FormerlySerializedAs("value")]
        public bool Value;
    }
}