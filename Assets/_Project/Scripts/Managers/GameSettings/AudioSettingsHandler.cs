using UnityEngine.UI;
using UnityEngine;

public sealed class AudioSettingsHandler : MonoBehaviour
{
	[Header("Buttons UI")]
	[SerializeField] private Button _backButton;
    
	[Header("Menu Manager")]
	[SerializeField] private MenuManager _menuManager;
	
	private void OnEnable()
	{
		SubscribeEvents();
	}

	private void OnDisable()
	{
		UnsubscribeEvents();
	}

	private void SubscribeEvents()
	{
		_backButton.onClick.AddListener(OnClick_BackToSettingsMenu);
	}

	private void UnsubscribeEvents()
	{
		_backButton.onClick.RemoveAllListeners();
	}
    
	private void OnClick_BackToSettingsMenu()
	{
		_menuManager.ShowMenu(Menu.SETTINGS);
	}
}