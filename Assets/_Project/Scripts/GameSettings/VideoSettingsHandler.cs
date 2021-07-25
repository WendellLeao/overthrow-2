using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using UnityEngine;
using TMPro;

public sealed class VideoSettingsHandler : MonoBehaviour
{
	[Header("UI")]
	[SerializeField] private TMP_Dropdown _resolutionDropdown;
	[SerializeField] private TMP_Dropdown _graphicsDropdown;

	[SerializeField] private Toggle _isFullscreenToggle;
	
	private Resolution[] _resolutions;

	private void OnEnable()
	{
		SubscribeEvents();
	}

	private void OnDisable()
	{
		UnsubscribeEvents();
	}
	
	private void Start()
	{
		LoadFullscreenToggle();
		
		AddResolutionsToDropdown();

		LoadResolution();
		
		LoadQualityLevel();
	}

	private void SubscribeEvents()
	{
		_resolutionDropdown.onValueChanged.AddListener(SetResolution);
		_graphicsDropdown.onValueChanged.AddListener(SetQualityLevel);

		_isFullscreenToggle.onValueChanged.AddListener(SetFullscreen);
	}

	private void UnsubscribeEvents()
	{
		_resolutionDropdown.onValueChanged.RemoveAllListeners();
		_graphicsDropdown.onValueChanged.RemoveAllListeners();
		
		_isFullscreenToggle.onValueChanged.RemoveAllListeners();
	}

	private void AddResolutionsToDropdown()
	{
		_resolutions = Screen.resolutions.Select(resolution => 
			new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();

		_resolutionDropdown.ClearOptions();

		List<string> options = new List<string>();
		
		for(int i = 0; i < _resolutions.Length; i++)
		{
			string option = _resolutions[i].width + "x" + _resolutions[i].height;
			
			options.Add(option);

			if(_resolutions[i].width == SaveSystem.GetLocalData().CurrentResolutionWidth && 
			   _resolutions[i].height == SaveSystem.GetLocalData().CurrentResolutionHeight)
			{
				SaveSystem.GetLocalData().CurrentDropdownResolutionIndex = i;
			}
		}

		_resolutionDropdown.AddOptions(options);
		
		_resolutionDropdown.value = SaveSystem.GetLocalData().CurrentDropdownResolutionIndex;
		
		_resolutionDropdown.RefreshShownValue();
	}

	//Load Settings
	private void LoadResolution()
	{
		Screen.SetResolution(
			SaveSystem.GetLocalData().CurrentResolutionWidth, 
			SaveSystem.GetLocalData().CurrentResolutionHeight, 
			SaveSystem.GetLocalData().IsFullscreen);
	}

	private void LoadFullscreenToggle()
	{
		_isFullscreenToggle.isOn = SaveSystem.GetLocalData().IsFullscreen;
		
		Screen.fullScreen = SaveSystem.GetLocalData().IsFullscreen;
	}

	private void LoadQualityLevel()
	{
		QualitySettings.SetQualityLevel(SaveSystem.GetLocalData().QualitySettingsIndex);

		_graphicsDropdown.value = SaveSystem.GetLocalData().QualitySettingsIndex;
	}

	//Setting new settings
	private void SetResolution(int resolutionIndex)
	{
		Resolution resolution = _resolutions[resolutionIndex];

		Screen.SetResolution(resolution.width, resolution.height, SaveSystem.GetLocalData().IsFullscreen);

		SaveSystem.GetLocalData().CurrentResolutionWidth = resolution.width;
		SaveSystem.GetLocalData().CurrentResolutionHeight = resolution.height;

		SaveSystem.SaveGameData();
	}
	
	private void SetQualityLevel(int qualityIndex)
	{
		SaveSystem.GetLocalData().QualitySettingsIndex = qualityIndex;
		
		QualitySettings.SetQualityLevel(qualityIndex);

		SaveSystem.SaveGameData();
	}

	private void SetFullscreen(bool isFullscreen)
	{
		SaveSystem.GetLocalData().IsFullscreen = isFullscreen;
		
		Screen.fullScreen = isFullscreen;

		SaveSystem.SaveGameData();
	}
}
