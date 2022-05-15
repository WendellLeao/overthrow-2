using _Project.Scripts.Managers.SceneManager;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UI
{
   public sealed class LoadingScreenHandler : MonoBehaviour
   {
      [Header("Async Scene Handler")]
      [SerializeField] private AsyncSceneHandler _asyncSceneHandler;
   
      [Header(("Loading Bar"))]
      [SerializeField] private Slider _slider;

      private void Update()
      {
         UpdateLoadingBar();
      }

      private void UpdateLoadingBar()
      {
         _slider.value = _asyncSceneHandler.GetNormalizedOperationProgress();
      }
   }
}
