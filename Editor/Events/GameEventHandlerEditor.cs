#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Dwarf.Events
{
    [CustomEditor(typeof(GameEvent))]
    public class GameEventHandlerEditor : Editor
    {
        private bool _useParameter = false;
        private int _parameterValue = 0;

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            GameEvent scriptableObject = (GameEvent)target;


            _useParameter = EditorGUILayout.Toggle("Use Parameter", _useParameter);

            if (_useParameter)
            {
                _parameterValue = EditorGUILayout.IntField("Parameter Value", _parameterValue);
            }

            if (GUILayout.Button("Raise Event"))
            {
                if (_useParameter)
                {
                    scriptableObject.RaiseEvent(_parameterValue);
                }
                else
                {
                    scriptableObject.RaiseEvent(); // No parameter provided
                }
            }
        }
    }
}
#endif
