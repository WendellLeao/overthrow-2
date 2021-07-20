using UnityEngine;

public sealed class LaserCollider : MonoBehaviour
{
    [Header("Game Events")]
    [SerializeField] private LocalGameEvents _localGameEvents;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<DeactivatableObject>(out DeactivatableObject deactivatableObject))
        {
            if(!deactivatableObject.GetIsActivated())
            {
                deactivatableObject.DeactivateObject();

                SoundManager.instance.Play("LaserCollision");

                _localGameEvents.OnLaserCollide?.Invoke();
            }
        }
    }
}
