using UnityEngine;


namespace Dwarf.ScriptableObjects
{
    [CreateAssetMenu(fileName = "StringVariable", menuName = "Scriptable Objects/StringVariable")]
    public class StringVariable : ScriptableObject
    {
        public string value;
    }
}