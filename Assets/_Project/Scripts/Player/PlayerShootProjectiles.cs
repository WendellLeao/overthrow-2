using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public sealed class PlayerShootProjectiles : MonoBehaviour
{
    [Header("Player Controller")]
    [SerializeField] private PlayerController _playerController;

    private void Start()
    {
        _playerController.PlayerInput.CharacterControls.Shoot.performed += _ => OnPlayerShoot_PerformShoot();
    }

    private void OnPlayerShoot_PerformShoot()
    {
        Debug.Log("has shooted");
    }
}
