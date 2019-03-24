using System;
using UnityEngine;

namespace MFramework
{
    public class Res : SimpleRC
    {
        public UnityEngine.Object Asset { get; private set; }

        public string Name { get; private set; }
        // 加载资源路径
        private string mAssetPath;
        public Res(string assetPath)
        {
            mAssetPath = assetPath;
            Name = assetPath;
        }
        /// <summary>
        /// 同步加载
        /// </summary>
        /// <returns></returns>
        public bool LoadSync()
        {
            return Asset = Resources.Load(mAssetPath);
        }
        /// <summary>
        /// 异步加载
        /// </summary>
        /// <param name="onLoaded"></param>
        public void LoadAsync(Action<Res> onLoaded)
        {
            ResourceRequest resRequest = Resources.LoadAsync(mAssetPath);
            resRequest.completed += operation =>
            {
                Asset = resRequest.asset;
                onLoaded(this);
            };
        }

        protected override void OnZeroRef()
        {
            if(Asset is GameObject)
            {
                Asset = null;
                Resources.UnloadUnusedAssets();
            }
            else
            {
                Resources.UnloadAsset(Asset);
            }
            ResManager.Instance.SharedLoadedRes.Remove(this);
            Asset = null;
        }
    }

}