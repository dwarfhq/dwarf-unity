using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Dwarf.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BoolVariable", menuName = "Scriptable Objects/BoolVariable", order = 1)]
    [MovedFrom("Assembly-CSharp")]
    public class BoolVariable : ScriptableObject
    {
        public bool value;
    }
}