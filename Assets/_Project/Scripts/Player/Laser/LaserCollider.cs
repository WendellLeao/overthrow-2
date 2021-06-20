using UnityEngine;

public sealed class LaserCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        DestructibleObject destructibleObject = other.GetComponent<DestructibleObject>();
        
        if(destructibleObject != null) 
        {
            if(destructibleObject.IsEnabled)
            {
                Cube cube = other.GetComponent<Cube>();

                if(cube != null) 
                    Debug.Log("You Lose!");
            }
            else
            {
                destructibleObject.DestroyObject();
            }
        }
    }
}