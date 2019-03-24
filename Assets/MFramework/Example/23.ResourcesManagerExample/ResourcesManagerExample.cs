using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MFramework
{
    public class ResourcesManagerExample : MonoBehaviour
    {

#if UNITY_EDITOR
        [UnityEditor.MenuItem("MFramework/Example/23.ResourcesManagerExample", false, 23)]
#endif
        static void MenuClicked()
        {
            // UnityEditor.EditorApplication.isPlaying = true;
            new GameObject("ResourcesManagerExample").AddComponent<ResourcesManagerExample>();
        }

        ResLoader mResLoader = new ResLoader();

        private void Awake()
        {
            
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(2.0f);
            mResLoader.LoadAsync<AudioClip>("yu", coinClip =>
            {
                Debug.Log(coinClip.name);
            });
        }
    }

}

