using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewGameEvent",  menuName = "Events/Game Event")]
public sealed class VoidEventChannel : ScriptableObject
{
	private List<VoidEventListener> eventListeners = new List<VoidEventListener>();

    public void RaiseEvent()
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
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