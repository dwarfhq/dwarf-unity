using UnityEngine;

namespace Dwarf.Utilities
{
    /// <summary>
    /// Exposes an attached 2D collider's events publicly
    /// </summary>
    public class ColliderEvents2D : ColliderEventsBase
    {

        [Space(10)]
        [Header("Events")]
        public TriggerEvent2D TriggerEnter;
        public TriggerEvent2D TriggerExit;
        public TriggerEvent2D TriggerStay;
        public CollisionEvent2D CollisionEnter;
        public CollisionEvent2D CollisionExit;
        public CollisionEvent2D CollisionStay;

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (!IsFiltered(collider.gameObject.tag)) return;
            TriggerEnter.Invoke(collider);
        }
        void OnTriggerExit2D(Collider2D collider)
        {
            if (!IsFiltered(collider.gameObject.tag)) return;
            TriggerExit.Invoke(collider);
        }
        void OnTriggerStay2D(Collider2D collider)
        {
            if (!IsFiltered(collider.gameObject.tag)) return;
            TriggerStay.Invoke(collider);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (!IsFiltered(collision.gameObject.tag)) return;
            CollisionEnter.Invoke(collision);
        }

        void OnCollisionExit2D(Collision2D collision)
        {
            if (!IsFiltered(collision.gameObject.tag)) return;
            CollisionExit.Invoke(collision);
        }

        void OnCollisionStay2D(Collision2D collision)
        {
            if (!IsFiltered(collision.gameObject.tag)) return;
            CollisionStay.Invoke(collision);
        }
    }
}