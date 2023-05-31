using UnityEngine;
using UnityEngine.Events;

namespace Dwarf.Events
{
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent eventHandler;
        public UnityEvent<int?> onEventRaised; // TODO: Figure out if we need the optional parameter here. It was great for bersærk, but maybe we need something else for other events?

        private void OnEnable()
        {
            // Register this event listener to the event handler
            if (eventHandler != null)
            {
                eventHandler.RegisterListener(this);
            }
        }

        private void OnDisable()
        {
            // Unregister this event listener from the event handler
            if (eventHandler != null)
            {
                eventHandler.UnregisterListener(this);
            }
        }

        public void OnEventRaised(int? playerId = null)
        {
            // Invoke the UnityEvent when the event is raised
            onEventRaised.Invoke(playerId);
        }
    }
}