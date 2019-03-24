using System;
using System.Collections.Generic;

namespace MFramework
{
    public class ResLoader
    {
        #region private
        private List<Res> mResRecords = new List<Res>();
        /// <summary>
        /// 从本地记录中获取资源
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        private Res GetResFromRecord(string assetName)
        {
            return mResRecords.Find(loadedAsset => loadedAsset.Name == assetName);
        }
        /// <summary>
        /// 从全局资源管理获取
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        private Res GetResFromResManager(string assetName)
        {
            return ResManager.Instance.SharedLoadedRes.Find(loadedAsset => loadedAsset.Name == assetName);
        }
        /// <summary>
        /// 添加到本地记录
        /// </summary>
        /// <param name="resFromResManager"></param>
        private void AddRes2Record(Res resFromResManager)
        {
            mResRecords.Add(resFromResManager);
            resFromResManager.Retain();
        }

        private Res CreateRes(string assetName)
        {
            Res res = new Res(assetName);
            ResManager.Instance.SharedLoadedRes.Add(res);
            this.AddRes2Record(res);
            return res;
        }

        private Res GetOrCreateRes(string assetName)
        {
            Res res = this.GetResFromRecord(assetName);
            if (res != null)
            {
                return res;
            }
            res = this.GetResFromResManager(assetName);
            if (res != null)
            {
                this.AddRes2Record(res);
                return res;
            }
            return res;
        }
        #endregion

        /// <summary>
        /// 同步加载资源
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public T LoadSync<T>(string assetName) where T : UnityEngine.Object
        {
            Res res = this.GetOrCreateRes(assetName);
            if (res != null)
            {
                return res.Asset as T;
            }

            res = this.CreateRes(assetName);
            res.LoadSync();

            return res.Asset as T;
        }
        /// <summary>
        /// 异步加载资源
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assetName"></param>
        /// <param name="onLoaded"></param>
        public void LoadAsync<T>(string assetName, Action<T> onLoaded) where T : UnityEngine.Object
        {
            Res res = this.GetOrCreateRes(assetName);
            if (res != null)
            {
                onLoaded(res.Asset as T);
                return;
            }
            
            res = this.CreateRes(assetName);
            res.LoadAsync(loadedRes =>
            {
                onLoaded(loadedRes.Asset as T);
            });
        }

        public void ReleaseAsset()
        {
            mResRecords.ForEach(loadedAsset => { loadedAsset.Release(); });
            mResRecords.Clear();
        }
    }

}

