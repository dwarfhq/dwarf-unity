using UnityEngine;

namespace Dwarf.Utilities
{
    /// <summary>
    /// Generic Singleton base class
    /// </summary>
    /// <typeparam name="T">Type of the class inheriting the Singleton behaviour</typeparam>
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        /// <summary>
        /// The Singleton instance
        /// </summary>
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    // If the instance is null, try to find an object of type T in the scene
                    _instance = FindObjectOfType<T>();

                    if (_instance == null)
                    {
                        // If no object of type T can be found in the scene, create a new instance
                        GameObject singleton = new GameObject(typeof(T).Name);
                        _instance = singleton.AddComponent<T>();
                    }
                }

                return _instance;
            }
        }

        [Header("Singleton Settings"), Tooltip("Defines if the Singleton should persist between scenes")]
        protected bool IsPersistent = true;

        public virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
                if (IsPersistent)
                    DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

}
