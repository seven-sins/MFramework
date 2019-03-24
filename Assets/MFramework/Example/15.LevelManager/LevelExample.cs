using System.Collections.Generic;
using UnityEngine;

namespace MFramework
{
    public class LevelExample : MonoBehaviourSimplify
    {
#if UNITY_EDITOR
        [UnityEditor.MenuItem("MFramework/Example/15.LevelManager", false, 15)]
#endif
        private static void MenuClicked()
        {
            // UnityEditor.EditorApplication.isPlaying = true;
            new GameObject("LevelExample").AddComponent<LevelExample>();
        }
        void Start()
        {
            LevelManager.Init(new List<string>
            {
                "Game",
                "Level"
            });
            LevelManager.LoadCurrent();

            Delay(5.0f, LevelManager.LoadNext);
        }

        protected override void OnBeforeDestroy()
        {
        }
    }

}
