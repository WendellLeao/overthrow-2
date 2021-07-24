using UnityEngine.UI;
using UnityEngine;

public sealed class WinGamePanelUI : MonoBehaviour
{
    [Header("Panels UI")]
    [SerializeField] private GameObject _winPanelObject;
    [SerializeField] private GameObject _endGamePanelObject;

    [Header("Buttons UI")]
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _mainMenuButton;

    [Header("Game Events")]
    [SerializeField] private GlobalGameEvents _globalGameEvents;

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
        _globalGameEvents.OnLevelCompleted += OnLevelCompleted_ShowWinPanelUI;

        _continueButton.onClick.AddListener(SceneHandler.LoadNextScene);
        _mainMenuButton.onClick.AddListener(SceneHandler.BackToMainMenu);
    }

    private void UnsubscribeEvents()
    {
        _globalGameEvents.OnLevelCompleted -= OnLevelCompleted_ShowWinPanelUI;

        _continueButton.onClick.RemoveAllListeners();
        _mainMenuButton.onClick.RemoveAllListeners();
    }

    private void OnLevelCompleted_ShowWinPanelUI()
    {
        if(SceneHandler.NextSceneExists())
        {
            _winPanelObject.SetActive(true);
        }
        else
        {
            _endGamePanelObject.SetActive(true);
        }
    }
}
