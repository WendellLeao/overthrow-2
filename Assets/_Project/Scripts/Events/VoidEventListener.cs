using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public sealed class VoidEventListener : MonoBehaviour
{
	[SerializeField] private List<EventAndResponse> eventsAndResponses = new List<EventAndResponse>();

	public void Respond(VoidEventChannel channel)
	{
        for(int i = 0; i < eventsAndResponses.Count; i++)
        {
            if(channel == eventsAndResponses[i]._channel)
            {
                eventsAndResponses[i].EventRaised();
            }
        }
	}

	private void OnEnable()
	{
		if(eventsAndResponses.Count >= 1)
        {
            foreach(EventAndResponse eventAndResponse in eventsAndResponses)
            {
                eventAndResponse._channel.RegisterListener(this);
            }
        }
	}

	private void OnDisable()
	{
		if(eventsAndResponses.Count >= 1)
        {
            foreach(EventAndResponse eventAndResponse in eventsAndResponses)
            {
                eventAndResponse._channel.UnregisterListener(this);
            }
        }
	}
}

[System.Serializable]
public sealed class EventAndResponse
{
	public VoidEventChannel _channel = default;
	public UnityEvent OnEventRaised;

	public void EventRaised()
    {
        if(OnEventRaised.GetPersistentEventCount() >= 1)
        {
            OnEventRaised.Invoke();
        }
	}
}