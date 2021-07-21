using UnityEngine;

public sealed class GameDataLoader : MonoBehaviour
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
		_asyncSceneHandler.LoadAdditiveSceneAsync(SceneEnum.MAIN_MENU);
	}
}
