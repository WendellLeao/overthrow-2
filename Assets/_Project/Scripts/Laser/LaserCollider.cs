using UnityEngine;

public sealed class LaserCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        IDestroyable destroyable = other.GetComponent<IDestroyable>();
        
        if(destroyable != null) 
            destroyable.DestroyObject();

        Cube cube = other.GetComponent<Cube>();
        
        if(cube != null && cube.IsEnabled) 
            Debug.Log("You Lose!");
    }
}
