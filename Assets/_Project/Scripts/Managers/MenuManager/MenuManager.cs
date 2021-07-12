using UnityEngine;
using UnityEngine.UI;

public sealed class MenuManager : MonoBehaviour
{
    [Header("Menu Containers")]
    [SerializeField] private GameObject _mainMenuObject;

    [Header("Menu Buttons")]
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _newGameButton;
    [SerializeField] private Button _quitButton;

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

        SoundManager.instance.PlaySoundtrack();
    }

    private void SubscribeEvents()
    {
        _continueButton.onClick.AddListener(OnClick_StartGame);
        _newGameButton.onClick.AddListener(OnClick_StartNewGame);

        _quitButton.onClick.AddListener(OnClick_Quit);
    }

    private void UnsubscribeEvents()
    {
        _continueButton.onClick.RemoveAllListeners();
        _newGameButton.onClick.RemoveAllListeners();

        _quitButton.onClick.RemoveAllListeners();
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    private void SetMenuObjectPosition()
    {
        _mainMenuObject.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }

    private void ShowMenu(Menu menu)
    {
        menu = Menu.MAIN;

        _mainMenuObject.SetActive(false);

        switch(menu)
        {
            case Menu.MAIN:
            {
                HandleMainMenu();
                break;
            }
        }
    }

    private void HandleMainMenu()
    {
        _mainMenuObject.SetActive(true);

        int firstLevelIndex = SceneHandler.GetActiveSceneIndex() + 2;
        _continueButton.gameObject.SetActive(SaveSystem.GetLocalData().currentSceneIndex > firstLevelIndex);
    }
    
    private void OnClick_StartGame()
    {
        SceneHandler.LoadNextScene();
    }

    private void OnClick_StartNewGame()
    {
        SaveSystem.DeleteSave();
        
        SceneHandler.LoadNextScene();
    }

    private void OnClick_Quit()
    {
        Debug.Log("Quit!");

        Application.Quit();
    }
}