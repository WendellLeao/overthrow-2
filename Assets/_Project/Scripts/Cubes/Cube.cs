using UnityEngine;

public sealed class Cube : MonoBehaviour, IDestroyable
{
    [Header("Materials")]
    [SerializeField] private Material _disabledMaterial;
    
    private bool _isEnabled = true;
    public bool IsEnabled => _isEnabled;

    public void DestroyObject()
    {
        Destroy(this.gameObject);
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
