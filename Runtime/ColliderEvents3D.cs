using UnityEngine;

namespace Dwarf
{
    namespace Utilities
    {
        /// <summary>
        /// Exposes an attached 3D collider's events publicly
        /// </summary>
        public class ColliderEvents3D : ColliderEventsBase
        {
            [Space(10)]
            [Header("Events")]
            public TriggerEvent3D TriggerEnter;
            public TriggerEvent3D TriggerExit;
            public TriggerEvent3D TriggerStay;
            public CollisionEvent3D CollisionEnter;
            public CollisionEvent3D CollisionExit;
            public CollisionEvent3D CollisionStay;

            void OnTriggerEnter(Collider collider)
            {
                if (!IsFiltered(collider.gameObject.tag)) return;
                TriggerEnter.Invoke(collider);
            }
            void OnTriggerExit(Collider collider)
            {
                if (!IsFiltered(collider.gameObject.tag)) return;
                TriggerExit.Invoke(collider);
            }
            void OnTriggerStay(Collider collider)
            {
                if (!IsFiltered(collider.gameObject.tag)) return;
                TriggerStay.Invoke(collider);
            }

            void OnCollisionEnter(Collision collision)
            {
                if (!IsFiltered(collision.gameObject.tag)) return;
                CollisionEnter.Invoke(collision);
            }

            void OnCollisionExit(Collision collision)
            {
                if (!IsFiltered(collision.gameObject.tag)) return;
                CollisionExit.Invoke(collision);
            }

            void OnCollisionStay(Collision collision)
            {
                if (!IsFiltered(collision.gameObject.tag)) return;
                CollisionStay.Invoke(collision);
            }
        }
    }
}
