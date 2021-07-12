using UnityEngine;
using UnityEngine.UI;

public sealed class LoadingScreenHandler : MonoBehaviour
{
   [Header("Async Scene Handler")]
   [SerializeField] private AsyncSceneHandler _asyncSceneHandler;
   
   [Header(("Loading Bar"))]
   [SerializeField] private Slider _slider;
  
   private void Start()
   {
      SetAsyncSceneIndex(SaveSystem.GetLocalData().currentSceneIndex);
   }

   private void Update()
   {
      UpdateLoadingBar();
   }

   private void SetAsyncSceneIndex(int sceneIndex)
   {
      _asyncSceneHandler.LoadAsyncScene(sceneIndex);
   }

   private void UpdateLoadingBar()
   {
      _slider.value = _asyncSceneHandler.GetNormalizedOperationProgress;
   }
}