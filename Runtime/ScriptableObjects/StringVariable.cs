using UnityEngine;


namespace Dwarf.ScritableObjects
{
    [CreateAssetMenu(fileName = "StringVariable", menuName = "Scriptable Objects/StringVariable")]
    public class StringVariable : ScriptableObject
    {
        public string value;
    }
}