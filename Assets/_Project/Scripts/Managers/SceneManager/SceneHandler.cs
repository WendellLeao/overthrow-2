using _Project.Scripts.Enums.Managers.SceneManager;

namespace _Project.Scripts.Managers.SceneManager
{
    public static class SceneHandler
    {
        public static void LoadScene(int sceneIndex)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
        }
    
        public static void LoadScene(SceneEnum sceneEnum)
        {
            int sceneEnumToInt = (int)sceneEnum;
        
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneEnumToInt);
        }

        public static void LoadNextScene()
        {
            LoadScene(GetNextSceneIndex());
        }
    
        public static void ReloadScene()
        {
            LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }

        public static void BackToMainMenu()
        {
            LoadScene(SceneEnum.MAIN_MENU);
        }

        public static bool NextSceneExists()
        {
            return GetNextSceneIndex() < UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
        }

        public static int GetActiveSceneIndex()
        {
            return UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        }
    
        public static int GetNextSceneIndex()
        {
            return UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1;
        }
    }
}
