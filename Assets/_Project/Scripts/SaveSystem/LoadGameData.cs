using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class LoadGameData : MonoBehaviour
{
	[Header("Async Scene Handler")]
	[SerializeField] private AsyncSceneHandler _asyncSceneHandler;

	private void Awake()
	{
		SaveSystem.LoadGameData();
		
		LoadAsyncScene();
	}
	
	private void LoadAsyncScene()
	{
		_asyncSceneHandler.LoadAsyncScene(SceneEnum.MAIN_MENU);
	}
}