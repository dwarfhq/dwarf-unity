using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Dwarf.Events
{
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField, FormerlySerializedAs("eventHandler")]
        GameEvent _eventHandler;
        [SerializeField, FormerlySerializedAs("onEventRaised")]
        UnityEvent<int?> _onEventRaised; // TODO: Figure out if we need the optional parameter here. It was great for bersærk, but maybe we need something else for other events?

        private void OnEnable()
        {
            // Register this event listener to the event handler
            if (_eventHandler != null)
            {
                _eventHandler.RegisterListener(this);
            }
        }

        private void OnDisable()
        {
            // Unregister this event listener from the event handler
            if (_eventHandler != null)
            {
                _eventHandler.UnregisterListener(this);
            }
        }

        public void OnEventRaised(int? playerId = null)
        {
            // Invoke the UnityEvent when the event is raised
            _onEventRaised.Invoke(playerId);
        }
    }
}