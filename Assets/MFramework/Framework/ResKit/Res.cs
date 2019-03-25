using System;

namespace MFramework
{
    public abstract class Res : SimpleRC
    {
        public UnityEngine.Object Asset { get; protected set; }

        public string Name { get; protected set; }
        // 加载资源路径
        // private string mAssetPath;
        /// <summary>
        /// 同步加载
        /// </summary>
        /// <returns></returns>
        public abstract bool LoadSync();
        /// <summary>
        /// 异步加载
        /// </summary>
        /// <param name="onLoaded"></param>
        public abstract void LoadAsync(Action<Res> onLoaded);

        protected abstract void Release();

        protected override void OnZeroRef()
        {
            Release();
        }
    }

}