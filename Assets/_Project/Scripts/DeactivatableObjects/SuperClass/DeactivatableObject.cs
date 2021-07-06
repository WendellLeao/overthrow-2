using UnityEngine;

public abstract class DeactivatableObject : MonoBehaviour
{
    [Header("Materials")]
    [SerializeField] protected Material _deactivatedMaterial;
    [SerializeField] protected MeshRenderer _meshRenderer;

    [Header("Detection")]
    [SerializeField] private LayerMask deactivatorObject;

    [Header("Enable Bolls")]
    private bool _isActivated = true;
    
    public bool GetIsActivated => _isActivated;
    
    public void DeactivateObject()
    {
        this.gameObject.SetActive(false);
    }

    protected virtual void OnCollisionEnter(Collision other)
    {
        int singleLayer = (int) Mathf.Log(deactivatorObject.value, 2);

        if(other.gameObject.layer == singleLayer)
        {
            _meshRenderer.material = _deactivatedMaterial;
            
            _isActivated = false;
        }
    }
}