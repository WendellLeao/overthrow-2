using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
    [Header("Player Components")]
    [SerializeField] private PlayerMouseLook _playerMouseLook;
    public PlayerMouseLook PlayerMouseLook => _playerMouseLook;

    private void Awake()
    {
        Cursor.visible = false;////////////////
    }
}