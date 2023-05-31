using UnityEngine;

namespace Dwarf.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BoolVariable", menuName = "Scriptable Objects/BoolVariable", order = 1)]
    public class BoolVariable : ScriptableObject
    {
        public bool value;
    }
}