using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public sealed class PlayerMovement : MonoBehaviour
{
    [Header("Player Controller")]
    [SerializeField] private PlayerController _playerController;
    
    private void Update()
    {
        HandleCameraMovement();
    }

    private void HandleCameraMovement()
    {

    }
}
