using UnityEngine;
using UnityEngine.UI;

public sealed class MenuHandler : MonoBehaviour
{
    [Header("Menu Containers")]
    [SerializeField] private GameObject _mainMenuObject;

    [Header("Menu Buttons")]
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _quitButton;
    
    [Header("Save System")]
    [SerializeField] private SaveSystem _saveSystem;

    private SceneHandler _sceneHandler = new SceneHandler();
    
    private Menu _currentMenu;

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
        ResumeGame();

        SetMenuObjectPosition();

        ShowMenu(Menu.MAIN);
    }

    private void SubscribeEvents()
    {
        _playButton.onClick.AddListener(OnClick_PlayGame);
        _quitButton.onClick.AddListener(OnClick_Quit);
    }

    private void UnsubscribeEvents()
    {
        _playButton.onClick.RemoveAllListeners();
        _quitButton.onClick.RemoveAllListeners();
    }

    private void ShowMenu(Menu menu)
    {
        menu = Menu.MAIN;

        _mainMenuObject.SetActive(false);

        switch(menu)
        {
            case Menu.MAIN:
                _mainMenuObject.SetActive(true);
                break;
        }
    }

    private void OnClick_PlayGame()
    {
        _sceneHandler.LoadScene(_saveSystem.LoadCurrentLevelIndex() + 1); //Skip Main Menu Scene (index 0)
    }

    private void OnClick_Quit()
    {
        Debug.Log("Quit");

        Application.Quit();
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    private void SetMenuObjectPosition()
    {
        _mainMenuObject.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }
}