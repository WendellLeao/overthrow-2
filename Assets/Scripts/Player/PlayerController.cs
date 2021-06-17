using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
    public static PlayerController instance {get; private set;}

    [Header("Player Components")]
    [SerializeField] private PlayerInput _playerInput;
    public PlayerInput PlayerInput => _playerInput;

    #region Singleton
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion
}
