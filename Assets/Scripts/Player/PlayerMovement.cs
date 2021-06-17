using UnityEngine;

public sealed class PlayerMovement : MonoBehaviour
{
    [Header("Player Controller")]
    [SerializeField] private PlayerController _playerController;
    private float _horizontalMouse, _verticalMouse;
    
    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        _horizontalMouse += Input.GetAxis("Mouse X");
        _verticalMouse -= Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(_verticalMouse * 1f, _horizontalMouse * 1f, 0);
    }
}
