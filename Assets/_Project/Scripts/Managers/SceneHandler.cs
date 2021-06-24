using UnityEngine.SceneManagement;

public class SceneHandler
{
    private bool _isLoadingScene;

    public SceneHandler()
    {
        _isLoadingScene = false;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        _isLoadingScene = true;
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        _isLoadingScene = true;
    }

    public void LoadNextScene()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void ReloadScene()
    {
        LoadScene(SceneManager.GetActiveScene().name);
    }
}