using UnityEngine;
using Cinemachine;

public sealed class CinemachinePOVExtension : CinemachineExtension
{
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        throw new System.NotImplementedException();
    }
}
