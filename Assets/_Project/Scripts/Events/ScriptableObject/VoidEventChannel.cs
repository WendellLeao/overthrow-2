using UnityEngine.Events;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGameEvent",  menuName = "Events/Game Event")]
public sealed class VoidEventChannel : ScriptableObject
{
    public UnityAction OnEventRaised;

    public void RaiseEvent()
	{
		if (OnEventRaised != null)
			OnEventRaised.Invoke();
	}
}