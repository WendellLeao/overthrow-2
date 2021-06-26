using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "NewGameEvent",  menuName = "Events/Game Event")]
public class GameEvent : ScriptableObject
{
	public UnityAction OnEventRaised;
}