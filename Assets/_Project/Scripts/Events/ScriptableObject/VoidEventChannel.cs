using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGameEvent",  menuName = "Events/Game Event")]
public sealed class VoidEventChannel : ScriptableObject
{
    private List<VoidEventListener> eventListeners = new List<VoidEventListener>();

    public void RaiseEvent()
    {
        for(int i = 0; i < eventListeners.Count; i++)
        {
            eventListeners[i].Respond(this);
        }
    }

    public void RegisterListener(VoidEventListener listener)
    {
        eventListeners.Add(listener);
    }

    public void UnregisterListener(VoidEventListener listener)
    {
        eventListeners.Remove(listener);
    }
}