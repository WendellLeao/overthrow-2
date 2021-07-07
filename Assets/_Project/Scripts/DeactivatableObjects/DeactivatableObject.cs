using UnityEngine;

public sealed class DeactivatableObject : MonoBehaviour
{
    [Header("Materials")]
    [SerializeField] private Material _deactivatedMaterial;

    [Header("Mesh Renderer")]
    [SerializeField] private MeshRenderer _meshRenderer;

    [Header("Detection")]
    [SerializeField] private LayerMask deactivatorObject;

    [Header("Enable Bolls")]
    private bool _isActivated = true;
    
    public bool GetIsActivated => _isActivated;

    public void DeactivateObject()
    {
        this.gameObject.SetActive(false);
    }

    public void SetDeactivatedMaterial(Material deactivatedMaterial)
    {
        _deactivatedMaterial = deactivatedMaterial;
    }

    private void OnCollisionEnter(Collision other)
    {
        //int singleLayer = (int) Mathf.Log(deactivatorObject.value, 2);

        if(other.gameObject.layer == 3)//Platform index
        {
            _meshRenderer.material = _deactivatedMaterial;
            
            _isActivated = false;
        }
    }
}