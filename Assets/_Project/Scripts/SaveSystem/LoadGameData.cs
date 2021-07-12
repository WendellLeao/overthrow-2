using UnityEngine;

public sealed class LoadGameData : MonoBehaviour
{
	[Header("Async Scene Handler")]
	[SerializeField] private AsyncSceneHandler _asyncSceneHandler;

	private void Awake()
	{
		SaveSystem.LoadGameData();
	}
	
	private void Start()
	{
		SetAsyncSceneIndex(1);
	}

	private void SetAsyncSceneIndex(int sceneIndex)
	{
		_asyncSceneHandler.LoadAsyncScene(sceneIndex);
	}
}