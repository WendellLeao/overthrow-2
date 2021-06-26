using UnityEngine;

public class SceneEventsManager : MonoBehaviour
{
    [Header("Scene Handler")]
    private SceneHandler _sceneHandler;

    public void ReloadScene()
    {
        _sceneHandler.ReloadScene();
    }

    public void LoadNextScene()
    {
        _sceneHandler.LoadNextScene();
    }

    private void Awake()
    {
        _sceneHandler = new SceneHandler();
    }
}