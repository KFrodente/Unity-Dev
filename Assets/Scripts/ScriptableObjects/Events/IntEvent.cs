using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "newIntEvent", menuName = "Events/Int Event")]
public class IntEvent : ScriptableObjectBase
{
    public UnityAction<int> onEventRaised;

    public void RaiseEvent(int value)
    {
        onEventRaised?.Invoke(value);
    }

    public void Subscribe(UnityAction<int> function)
    {
        onEventRaised += function;
    }

    public void UnSubscribe(UnityAction<int> function)
    {
        onEventRaised -= function;
    }
}
