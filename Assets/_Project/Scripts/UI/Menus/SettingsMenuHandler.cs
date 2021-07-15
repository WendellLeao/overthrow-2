using UnityEngine.UI;
using UnityEngine;

public sealed class SettingsMenuHandler : MonoBehaviour
{
	[Header("Buttons UI")]
	[SerializeField] private Button _videoButton; 
	[SerializeField] private Button _audioButton; 
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
		_videoButton.onClick.AddListener(OnClick_ShowVideoMenu);
		_audioButton.onClick.AddListener(OnClick_ShowAudioMenu);
		_backButton.onClick.AddListener(OnClick_BackToMainMenu);
	}

	private void UnsubscribeEvents()
	{
		_videoButton.onClick.RemoveAllListeners();
		_audioButton.onClick.RemoveAllListeners();
		_backButton.onClick.RemoveAllListeners();
	}

	private void OnClick_ShowVideoMenu()
	{
		_menuManager.ShowMenu(Menu.VIDEO_SETTINGS);
	}

	private void OnClick_ShowAudioMenu()
	{
		_menuManager.ShowMenu(Menu.AUDIO_SETTINGS);
	}

	private void OnClick_BackToMainMenu()
	{
		_menuManager.ShowMenu(Menu.MAIN);
	}
}