using UnityEngine;

public sealed class LaserCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        DeactivatingObject deactivatingObject = other.GetComponent<DeactivatingObject>();
        
        if(deactivatingObject != null) 
        {
            if(deactivatingObject.IsEnabled)
            {
                Cube cube = other.GetComponent<Cube>();

                if(cube != null) 
                    Debug.Log("You Lose!");
            }
            else
            {
                deactivatingObject.DestroyObject();
            }
        }
    }
}