using System.Collections;
using UnityEngine;

namespace _Project.Scripts.DeactivatableObjects
{
    public sealed class DeactivatableObject : MonoBehaviour
    {
        [Header("Materials")]
        [SerializeField] private Material _deactivatedMaterial;

        [Header("Mesh Renderer")]
        [SerializeField] private MeshRenderer _meshRenderer;

        [Header("Detection")]
        [SerializeField] private LayerMask _deactivatorObject;
    
        [Header(("Check Object Position"))]
        [SerializeField] private float _minimumDistanceToDisable;
        [SerializeField] private float _maximumDistanceToDisable;
    
        [SerializeField] private float _checkPositionRate;

        [Header("Enable Bolls")]
        private bool _isActivated = true;
    
        public void DeactivateObject()
        {
            gameObject.SetActive(false);

            IsActivated = true;
        }

        private void OnEnable()
        {
            StartCoroutine(CheckObjectPosition());
        }

        private void OnCollisionEnter(Collision other)
        {
            if ((_deactivatorObject & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
            {
                _meshRenderer.material = _deactivatedMaterial;
            
                _isActivated = false;
            }
        }
    
        private IEnumerator CheckObjectPosition()
        {
            yield return new WaitForSeconds(_checkPositionRate);
        
            if(IsWithinTheLimits())
            {
                StartCoroutine(CheckObjectPosition());
            }
            else
            {
                DeactivateObject();
            }
        }

        private bool IsWithinTheLimits()
        {
            Vector3 objectPosition = transform.position;
            return objectPosition.y > _minimumDistanceToDisable && objectPosition.y < _maximumDistanceToDisable;
        }

        public bool IsActivated
        {
            get { return _isActivated; }
            set { _isActivated = value; }
        }

        public void SetDeactivatedMaterial(Material deactivatedMaterial)
        {
            _deactivatedMaterial = deactivatedMaterial; 
        }
    }
}
