using Dwarf.Utilities;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Triggers a unity event during Start if all conditions are satisfied
/// </summary>
public class ConditionalEffectTrigger : MonoBehaviour
{
    public ConditionBase[] Conditions;

    public UnityEvent OnConditionsSatified;

    private void Start()
    {
        for (int i = 0; i < Conditions.Length; i++)
        {
            if (!Conditions[i].IsSatisfied)
            {
                return;
            }
        }

        OnConditionsSatified.Invoke();
    }
}
