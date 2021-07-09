using System.Collections;
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

        _isActivated = true;
    }

    public void SetDeactivatedMaterial(Material deactivatedMaterial)
    {
        _deactivatedMaterial = deactivatedMaterial;
    }

    private void Update()
    {
        StartCoroutine(CheckObjectPosition());
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

    private IEnumerator CheckObjectPosition()
    {
        float timeToCheck = 0.5f;

        yield return new WaitForSeconds(timeToCheck);

        float distanceToDisable = 120f;

        if(transform.position.y <= -distanceToDisable || transform.position.y >= distanceToDisable / 1.5f)
        {
            DeactivateObject();
        }
    }
}