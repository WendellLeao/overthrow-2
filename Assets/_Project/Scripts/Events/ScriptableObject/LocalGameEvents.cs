using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "NewLocalGameEvents",  menuName = "Events/Local Game Events")]
public sealed class LocalGameEvents : ScriptableObject
{
    public UnityAction OnHealthChanged;

    public delegate void DelegateOnReadPlayerInputs(PlayerInputData playerInputData);
    public DelegateOnReadPlayerInputs OnReadPlayerInputs;

    public delegate void DelegateOnAmmoChanged(int currentProjectileAmount);
    public DelegateOnAmmoChanged OnAmmoChanged;
}