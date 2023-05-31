using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Dwarf.Events
{
    [CreateAssetMenu(fileName = "New Game Event", menuName = "Scriptable Objects/Game Event")]
    [MovedFrom(true, sourceAssembly: "Assembly-CSharp", sourceClassName: "GameEvent")]
    public class GameEvent : ScriptableObject
    {
        private readonly List<GameEventListener> _eventListeners = new();

        public void RaiseEvent(int? playerId = null)
        {
            // Notify all registered event listeners
            for (int i = _eventListeners.Count - 1; i >= 0; i--)
            {
                _eventListeners[i].OnEventRaised(playerId);
            }
        }

        public void RegisterListener(GameEventListener listener)
        {
            // Add the listener to the list of event listeners
            _eventListeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener listener)
        {
            // Remove the listener from the list of event listeners
            _eventListeners.Remove(listener);
        }
    }
}