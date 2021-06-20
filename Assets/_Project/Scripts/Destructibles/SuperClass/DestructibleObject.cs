using UnityEngine;

public abstract class DestructibleObject : MonoBehaviour
{
    [Header("Materials")]
    [SerializeField] private Material _disabledMaterial;

    [Header("Enable Bolls")]
    private bool _isEnabled = true;
    public bool IsEnabled => _isEnabled;
    
    public void DestroyObject()
    {
        Destroy(this.gameObject);
    }

    private void Update()
    {
        if(transform.position.y <= -120f)
            DestroyObject();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ground")
        {
            GetComponent<MeshRenderer>().material = _disabledMaterial;
            _isEnabled = false;
        }
    }
}
