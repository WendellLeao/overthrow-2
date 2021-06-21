using UnityEngine;

public sealed class LaserCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<DestructibleObject>(out DestructibleObject destructibleObject))
        {
            if(destructibleObject.GetIsEnabled)
            {
                if(other.TryGetComponent<Cube>(out Cube cube))
                {
                    Debug.Log("You Lose!");
                }
            }
            else
            {
                destructibleObject.DestroyObject();
            }
        }
    }
}