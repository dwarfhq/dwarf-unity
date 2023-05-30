using UnityEngine;

namespace Dwarf.ScritableObjects
{

    [CreateAssetMenu(fileName = "FloatVariable", menuName = "Scriptable Objects/FloatVariable", order = 1)]
    public class FloatVariable : ScriptableObject
    {
        public float value;
    }
}