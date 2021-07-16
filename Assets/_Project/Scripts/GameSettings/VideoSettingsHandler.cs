using System.Collections.Generic;
using UnityEngine.UI;
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
		AddResolutionsToDropdown();
		
		SetStartResolution();

		SetStartFullscreenToggle();
		
		SetStartQualityLevel();
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
		_resolutions = Screen.resolutions;

		_resolutionDropdown.ClearOptions();

		List<string> options = new List<string>();

		int currentResolutionIndex = 0;
		for(int i = 0; i < _resolutions.Length; i++)
		{
			string option = _resolutions[i].width + "x" + _resolutions[i].height;
			options.Add(option);

			if(_resolutions[i].width == Screen.currentResolution.width && 
			   _resolutions[i].height == Screen.currentResolution.height)
			{
				currentResolutionIndex = i;
			}
		}

		_resolutionDropdown.AddOptions(options);
		_resolutionDropdown.value = currentResolutionIndex;
		_resolutionDropdown.RefreshShownValue();
	}

	private void SetStartResolution()
	{
		int resolutionIndex = SaveSystem.GetLocalData().resolutionIndex;
		
		Resolution resolution = _resolutions[resolutionIndex];

		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

		_resolutionDropdown.value = resolutionIndex;
	}
	
	private void SetStartFullscreenToggle()
	{
		if (SaveSystem.GetLocalData().isGameFullscreen)
		{
			_isFullscreenToggle.isOn = true;
		}
		else
		{
			_isFullscreenToggle.isOn = false;
		}
	}

	private void SetStartQualityLevel()
	{
		QualitySettings.SetQualityLevel(SaveSystem.GetLocalData().qualitySettingsIndex);

		_graphicsDropdown.value = SaveSystem.GetLocalData().qualitySettingsIndex;
	}

	private void SetResolution(int resolutionIndex)
	{
		Resolution resolution = _resolutions[resolutionIndex];

		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

		SaveSystem.GetLocalData().resolutionIndex = resolutionIndex;

		SaveSystem.SaveGameData();
	}
	
	private void SetQualityLevel(int qualityIndex)
	{
		SaveSystem.GetLocalData().qualitySettingsIndex = qualityIndex;
		
		QualitySettings.SetQualityLevel(qualityIndex);

		SaveSystem.SaveGameData();
	}

	private void SetFullscreen(bool isFullscreen)
	{
		SaveSystem.GetLocalData().isGameFullscreen = isFullscreen;
		
		Screen.fullScreen = isFullscreen;

		SaveSystem.SaveGameData();
	}
}