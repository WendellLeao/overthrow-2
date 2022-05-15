using _Project.Scripts.DeactivatableObjects;
using _Project.Scripts.Enums.Managers.SoundManager;
using _Project.Scripts.Events.ScriptableObject;
using _Project.Scripts.Managers.SoundManager;
using UnityEngine;

namespace _Project.Scripts.Player.Laser
{
    public sealed class LaserCollider : MonoBehaviour
    {
        [Header("Game Events")]
        [SerializeField] private LocalGameEvents _localGameEvents;

        [Header("Laser Materials")]
        [SerializeField] private MeshRenderer _meshRenderer;
    
        [SerializeField] private Material _laserCollisionMaterial;
    
        [SerializeField] private Material _defaultLaserMaterial;

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent<DeactivatableObject>(out DeactivatableObject deactivatableObject))
            {
                //_meshRenderer.material = _laserCollisionMaterial;
            
                if(!deactivatableObject.IsActivated)
                {
                    deactivatableObject.DeactivateObject();

                    SoundManager.instance.PlaySound3D(Sound.LASER_COLLISION, transform.position);

                    _localGameEvents.OnLaserCollide?.Invoke();
                }
            }
        }
    
        // private void OnTriggerExit(Collider other)
        // {
        //     if(other.TryGetComponent<DeactivatableObject>(out DeactivatableObject deactivatableObject))
        //     {
        //         Debug.Log("exit");
        //         _meshRenderer.material = _defaultLaserMaterial;
        //         _isTouching = false;
        //     }
        // }
    }
}
