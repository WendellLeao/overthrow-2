using UnityEngine;

public sealed class LaserCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<DeactivatableObject>(out DeactivatableObject deactivatableObject))
        {
            if(!deactivatableObject.GetIsActivated)
            {
                deactivatableObject.DeactivateObject();

                SoundManager.instance.Play("LaserCollision");
            }
        }
    }
}