using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public sealed class AsyncSceneHandler : MonoBehaviour
{
    private AsyncOperation _asyncOperation;

    private float _normalizedAsyncOperationProgress;

    public float GetNormalizedOperationProgress => _normalizedAsyncOperationProgress;
    
    public void LoadAsyncScene(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }
    
    private IEnumerator LoadAsynchronously(int sceneIndex)
    {
        _asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!_asyncOperation.isDone)
        {
            _normalizedAsyncOperationProgress = Mathf.Clamp01(_asyncOperation.progress / 0.9f);
            
            yield return null;
        }
    }
}