using System.Collections;
using UnityEngine;

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
        this.gameObject.SetActive(false);

        IsActivated = true;
    }

    private void Start()
    {
        StartCoroutine(CoroutineCheckObjectPosition());
    }

    private void OnCollisionEnter(Collision other)
    {
        if ((_deactivatorObject & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
        {
            _meshRenderer.material = _deactivatedMaterial;
            
            _isActivated = false;
        }
    }
    
    private IEnumerator CoroutineCheckObjectPosition()
    {
        while(transform.position.y > _minimumDistanceToDisable && transform.position.y < _maximumDistanceToDisable)
        {
            yield return new WaitForSeconds(_checkPositionRate);
            
            Debug.Log("Courotine method calls");

            yield return null;
        }

        DeactivateObject();
    }

    public bool IsActivated
    {
        get => _isActivated; 
        set => _isActivated = value; 
    }

    public void SetDeactivatedMaterial(Material deactivatedMaterial)
    {
        _deactivatedMaterial = deactivatedMaterial; 
    }
}
