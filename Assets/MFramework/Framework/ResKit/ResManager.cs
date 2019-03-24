using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MFramework
{
    public class ResManager : MonoSingleton<ResManager>
    {
        public List<Res> SharedLoadedRes = new List<Res>();

#if UNITY_EDITOR
        private void OnGUI()
        {
            if (Input.GetKey(KeyCode.F1))
            {
                GUILayout.BeginVertical();

                SharedLoadedRes.ForEach(loadedRes =>
                {
                    GUILayout.Label(string.Format("Name:{0} RefCount:{1}", loadedRes.Name, loadedRes.RefCount));
                });
                GUILayout.EndVertical();
            }
        }
#endif
    }

}
