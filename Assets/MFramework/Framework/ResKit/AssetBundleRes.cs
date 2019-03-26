using System;
using UnityEngine;

namespace MFramework
{
    public class AssetBundleRes : Res
    {
        private static AssetBundleManifest mManifest;

        public static AssetBundleManifest Manifest
        {
            get
            {
                if (!mManifest)
                {
                    AssetBundle mainBundle = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/StreamingAssets");
                    mManifest = mainBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
                }
                return mManifest;
            }
        }

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
            State = ResState.Waiting;
        }

        private ResLoader mResLoader = new ResLoader();

        /// <summary>
        /// 同步加载
        /// </summary>
        /// <returns></returns>
        public override bool LoadSync()
        {
            State = ResState.Loading;
            string[] dependencyBundleNames = Manifest.GetDirectDependencies(mAssetPath.Substring(Application.streamingAssetsPath.Length + 1));
            foreach(string dependencyBundleName in dependencyBundleNames)
            {
                mResLoader.LoadSync<AssetBundle>(Application.streamingAssetsPath + "/" + dependencyBundleName);
            }
            assetBundle = AssetBundle.LoadFromFile(mAssetPath);
            State = ResState.Loaded;

            return assetBundle;
        }
        /// <summary>
        /// 异步加载
        /// </summary>
        /// <param name="onLoaded"></param>
        public override void LoadAsync(Action<Res> onLoaded)
        {
            State = ResState.Loading;
            AssetBundleCreateRequest assetBundleRequest = AssetBundle.LoadFromFileAsync(mAssetPath);
            assetBundleRequest.completed += operation =>
            {
                assetBundle = assetBundleRequest.assetBundle;
                State = ResState.Loaded;
                onLoaded(this);
            };
        }

        protected override void Release()
        {
            if(assetBundle != null)
            {
                assetBundle.Unload(true);
                Asset = null;

                mResLoader.Release();
                mResLoader = null;
            }
            
            ResManager.Instance.SharedLoadedRes.Remove(this);
        }

    }

}