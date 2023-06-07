using UnityEngine;
using UnityEngine.Serialization;

namespace Dwarf.ScriptableObjects
{
    [CreateAssetMenu(fileName = "StringVariable", menuName = "Scriptable Objects/StringVariable")]
    public class StringVariable : ScriptableObject
    {
        [FormerlySerializedAs("value")]
        public string Value;
    }
}