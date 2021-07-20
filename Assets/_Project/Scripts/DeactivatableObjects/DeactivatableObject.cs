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
    
    /// <summary>
    /// vai aqui uma dica de "manter um padrão"
    /// sei que metodos publicos vem acima de metodos privados, good.
    /// mas, para metodos que são só "Get / Set"  sugerimos tu colocar eles laaaaa no final do script...
    /// </summary>
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

    public void SetIsActivated(bool isActivated)
    {
        _isActivated = isActivated;
    }

    private void Update()
    {
        /// não acho uma boa isso aqui que tu fez... Tu esta chamando uma Coroutine no update, isso é cagada.
        /// tipo, em 0.5 segundos (que é o tempo ali que a coroutine espera) tu ja rodou o update oq? umas 30 vezes no minimo
        /// então tu ja executtou essa coroutine 30x sendo que a 1a ainda nem se quer finalizou...
        /// o que tu deveria fazer aqui é um "Loop de coroutine"
        /// ou seja: a coroutine chama ela mesma qnd acaba. Again, isso que tu fez aqui na real pode fuder a performance do jogo legal.
        StartCoroutine(CheckObjectPosition());
    }

    private void OnCollisionEnter(Collision other)
    {
        if ((deactivatorObject & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
        {
            _meshRenderer.material = _deactivatedMaterial;
            
            _isActivated = false;
        }
    }

    private IEnumerator CheckObjectPosition()
    {
        float timeToCheck = 0.5f;

        yield return new WaitForSeconds(timeToCheck);

        
        /// evite numeros magicos (hardcoded)
        /// aquele ali de cima, timeToCheck é passavel, agora "distance to disable" não.
        /// sempre  coloque essas coisas como variveis serializadas, mesmo que seja um valor que  po 120 ta good e tu não pretende mudar... a real é que "you never know".
        float distanceToDisable = 120f;

        if(transform.position.y <= -distanceToDisable || transform.position.y >= distanceToDisable / 1.5f)
        {
            DeactivateObject();
        }
    }
}