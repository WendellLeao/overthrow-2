using UnityEngine;

[RequireComponent(typeof(PlayerInputListener))]
public sealed class PlayerMouseLook : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private Transform _cameraTransform;

    [Header("Sensitivity")]
    [SerializeField] private float _horizontalSensitivity;
    [SerializeField] private float _verticalSensitivy;

    [Header("Game Events")]
    [SerializeField] private LocalGameEvents _localGameEvent;
    
    private float _horizontalRotation = 0f, _horizontalMouse, _verticalMouse;

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    private void Update()
    {
        HandleCameraVerticalRotation();
        HandlePlayerHorizontalRotation();
    }

    private void SubscribeEvents()
    {
        _localGameEvent.OnReadPlayerInputs += SetMouseInput;
    }

    private void UnsubscribeEvents()
    {
        _localGameEvent.OnReadPlayerInputs -= SetMouseInput;
    }

    private void HandleCameraVerticalRotation()
    {
        _horizontalRotation -= _verticalMouse;
        _horizontalRotation = Mathf.Clamp(_horizontalRotation, -90f, 90f);
        
        _cameraTransform.localRotation = Quaternion.Euler(_horizontalRotation, 0f, 0f);
    }
    
    private void HandlePlayerHorizontalRotation()
    {
        this.transform.Rotate(Vector3.up, _horizontalMouse);
    }

    private void SetMouseInput(PlayerInputData playerInputData)
    {
        _horizontalMouse = playerInputData.MousePosition.x * _horizontalSensitivity * Time.deltaTime;
        _verticalMouse = playerInputData.MousePosition.y * _verticalSensitivy * Time.deltaTime;
    }
}