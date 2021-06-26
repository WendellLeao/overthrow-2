using UnityEngine.Events;
using UnityEngine;

public class VoidEventListener : MonoBehaviour
{
    [SerializeField] private VoidEventChannel _channel = default;

	public UnityEvent OnEventRaised;

	private void OnEnable()
	{
		if (_channel != null)
			_channel.OnEventRaised += Respond;
	}

	private void OnDisable()
	{
		if (_channel != null)
			_channel.OnEventRaised -= Respond;
	}

	private void Respond()
	{
		if (OnEventRaised != null)
			OnEventRaised.Invoke();
	}
}