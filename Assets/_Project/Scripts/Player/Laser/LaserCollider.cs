using UnityEngine;

public sealed class LaserCollider : MonoBehaviour
{
    [Header("Game Events")]
    [SerializeField] private LocalGameEvents _localGameEvents;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<DeactivatableObject>(out DeactivatableObject deactivatableObject))
        {
            if(!deactivatableObject.IsActivated)
            {
                deactivatableObject.DeactivateObject();

                SoundManager.instance.PlaySound3D(Sound.LASER_COLLISION, transform.localPosition);

                _localGameEvents.OnLaserCollide?.Invoke();
            }
        }
    }
}
