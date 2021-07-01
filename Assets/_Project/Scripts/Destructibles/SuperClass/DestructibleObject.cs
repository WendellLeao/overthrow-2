using UnityEngine;

public abstract class DestructibleObject : MonoBehaviour
{
    [Header("Materials")]
    [SerializeField] private Material _disabledMaterial;
    [SerializeField] private MeshRenderer _meshRenderer;

    [Header("Detection")]
    [SerializeField] private LayerMask deactivatorObject;

    [Header("Enable Bolls")]
    private bool _isEnabled = true;
    
    public bool GetIsEnabled => _isEnabled;
    
    public void DestroyObject()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        int singleLayer = (int) Mathf.Log(deactivatorObject.value, 2);

        if(other.gameObject.layer == singleLayer)
        {
            _meshRenderer.material = _disabledMaterial;
            
            _isEnabled = false;
        }
    }
}