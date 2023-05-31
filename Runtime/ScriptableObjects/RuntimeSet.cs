using System.Collections.Generic;
using UnityEngine;

namespace Dwarf.ScriptableObjects
{
    public abstract class RuntimeSet<T> : ScriptableObject
    {
        public List<T> Values = new List<T>();

        public void Add(T t)
        {
            if (!Values.Contains(t))
            {
                Values.Add(t);
            }
        }
        public void Remove(T t)
        {
            if (Values.Contains(t))
            {
                Values.Remove(t);
            }
        }
    }
}