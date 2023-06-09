using Dwarf.Events;
using System.Collections.Generic;
using UnityEngine;

namespace Dwarf.Utilities
{
    public class EventTrigger : MonoBehaviour
    {
        [Header("Event")]
        [SerializeField]
        GameEvent _onTriggerEnter;
        [SerializeField]
        float _cooldownTime = 10f;
        float _currentCooldownTime;
        bool _isTriggered = false;

        [Space(10)]
        [Header("Filter")]
        [SerializeField]
        [Tooltip("Only GameObjects with these tags will trigger the Event")]
        List<string> _tags = new();
        [SerializeField]
        [Tooltip("When checked the event will only be triggered by calling EventTrigger.Trigger()")]
        bool _externalTriggerOnly = false;
        [SerializeField]
        ConditionBase[] _selectionConditions;

        void Awake()
        {
            _currentCooldownTime = _cooldownTime;
        }

        void Update()
        {
            if (_isTriggered)
            {
                _currentCooldownTime -= Time.deltaTime;
                if (_currentCooldownTime <= 0f)
                {
                    _isTriggered = false;
                }
            }
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (_externalTriggerOnly) return;
            if (!IsFiltered(collider.gameObject.tag)) return;

            foreach (var condition in _selectionConditions)
            {
                if (!condition.IsSatisfied) return;
            }

            Trigger();
        }

        public void Trigger()
        {
            if (!_isTriggered)
            {
                _onTriggerEnter.RaiseEvent();
                _isTriggered = true;
                _currentCooldownTime = _cooldownTime;
            }
        }

        /// <summary>
        /// Check whether a given tag is allowed through the filter
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <returns><example>true</example>, if the tag is allowed. Otherwise, <example>false</example></returns>
        bool IsFiltered(string tag)
        {
            if (_tags == null || _tags.Count == 0) return true;
            if (_tags.Contains(tag)) return true;
            return false;
        }
    }
}