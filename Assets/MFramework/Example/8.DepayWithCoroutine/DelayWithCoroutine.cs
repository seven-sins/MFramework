using UnityEngine;

namespace MFramework
{
    public class DelayWithCoroutine : MonoBehaviourSimplify
    {

#if UNITY_EDITOR
        [UnityEditor.MenuItem("MFramework/Example/8.定时功能", false, 8)]
#endif
        private static void MenuClicked()
        {
            UnityEditor.EditorApplication.isPlaying = true;
            new GameObject("Hide").AddComponent<DelayWithCoroutine>();
        }

        protected override void OnBeforeDestroy()
        {
        }

        void Start()
        {
            Delay(5.0f, () => {
                Debug.Log("5s后执行");
                Hide();
            });
        }
    }

}
