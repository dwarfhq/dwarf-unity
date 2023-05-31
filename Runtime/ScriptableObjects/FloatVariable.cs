using UnityEngine;

namespace Dwarf.ScriptableObjects
{

    [CreateAssetMenu(fileName = "FloatVariable", menuName = "Scriptable Objects/FloatVariable", order = 1)]
    public class FloatVariable : ScriptableObject
    {
        public float value;
    }
}