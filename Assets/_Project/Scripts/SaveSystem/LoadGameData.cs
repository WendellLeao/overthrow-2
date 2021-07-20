using UnityEngine;

public sealed class LoadGameData : MonoBehaviour
{
	/// <summary>
	/// o Nome LoadGameData me remete a um script que vai guaradar informação. Bom não é o caso aqui, então cuidado com nomenclaturas...
	/// </summary>
	
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