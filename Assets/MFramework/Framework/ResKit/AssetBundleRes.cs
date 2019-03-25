using System;
using UnityEngine;

namespace MFramework
{
    public class AssetBundleRes : Res
    {
        public AssetBundle assetBundle {
            get { return Asset as AssetBundle; }
            set { Asset = value; }
        }
        // 加载资源路径
        private string mAssetPath;
        public AssetBundleRes(string assetPath)
        {
            mAssetPath = assetPath;
            Name = assetPath;
        }
        /// <summary>
        /// 同步加载
        /// </summary>
        /// <returns></returns>
        public override bool LoadSync()
        {
            return assetBundle = AssetBundle.LoadFromFile(mAssetPath);
        }
        /// <summary>
        /// 异步加载
        /// </summary>
        /// <param name="onLoaded"></param>
        public override void LoadAsync(Action<Res> onLoaded)
        {
            AssetBundleCreateRequest assetBundleRequest = AssetBundle.LoadFromFileAsync(mAssetPath);
            assetBundleRequest.completed += operation =>
            {
                assetBundle = assetBundleRequest.assetBundle;
                onLoaded(this);
            };
        }

        protected override void Release()
        {
            if(assetBundle != null)
            {
                assetBundle.Unload(true);
                Asset = null;
            }
            
            ResManager.Instance.SharedLoadedRes.Remove(this);
        }

    }

}