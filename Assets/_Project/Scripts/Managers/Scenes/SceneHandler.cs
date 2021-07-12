using UnityEngine.SceneManagement;

public static class SceneHandler
{
    public static void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public static void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        LoadScene(nextSceneIndex);
    }
    
    public static void ReloadScene()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void BackToMainMenu()
    {
        SceneManager.LoadScene(1);//Main Menu index
    }

    public static bool NextSceneExists()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        return nextSceneIndex < SceneManager.sceneCountInBuildSettings;
    }

    public static int GetActiveSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
    
    public static int GetNextSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex + 1;
    }
}