using UnityEngine;
using Cinemachine;

public sealed class CinemachinePOVExtension : CinemachineExtension
{
    [SerializeField] private float _horizontalSpeed, _verticalSpeed, _clampAngle;
    
    private PlayerInput _playerInput;
    
    private Vector3 _startRotation;


    protected override void Awake()
    {
        _playerInput = PlayerController.instance.PlayerInput;

        base.Awake();
    }

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if(vcam.Follow && stage == CinemachineCore.Stage.Aim)
        {
            if(_startRotation == null)    
                _startRotation = transform.localRotation.eulerAngles;

            Vector2 deltaInput = _playerInput.GetMouseDelta();
            _startRotation.x += deltaInput.x * _verticalSpeed * Time.deltaTime;
            _startRotation.y += deltaInput.x * _horizontalSpeed * Time.deltaTime;

            _startRotation.y = Mathf.Clamp(_startRotation.y, -_clampAngle, _clampAngle);
            
            state.RawOrientation = Quaternion.Euler(-_startRotation.y, _startRotation.x, 0f);
        }
    }
}
