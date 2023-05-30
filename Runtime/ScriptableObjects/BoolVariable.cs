using UnityEngine;

namespace Dwarf.ScritableObjects
{
    [CreateAssetMenu(fileName = "BoolVariable", menuName = "Scriptable Objects/BoolVariable", order = 1)]
    public class BoolVariable : ScriptableObject
    {
        public bool value;
    }
}