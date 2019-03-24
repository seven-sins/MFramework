using System.Collections.Generic;
using UnityEngine;

namespace MFramework
{
    public class ResourceLoader
    {
        public static List<Res> SharedLoadedRes = new List<Res>();

        private List<Res> mResRecords = new List<Res>();

        public T LoadAsset<T>(string assetName) where T : Object
        {
            Res res = mResRecords.Find(loadedAsset => loadedAsset.Name == assetName);
            if (res != null)
            {
                return res.Asset as T;
            }
            res = SharedLoadedRes.Find(loadedAsset => loadedAsset.Name == assetName);
            if (res != null)
            {
                mResRecords.Add(res);
                res.Retain();
                return res as T;
            }

            T asset = Resources.Load<T>(assetName);
            res = new Res(asset);
            res.Retain();

            mResRecords.Add(res);
            SharedLoadedRes.Add(res);

            return asset;
        }

        public void ReleaseAsset()
        {
            mResRecords.ForEach(loadedAsset => { loadedAsset.Release(); });
            mResRecords.Clear();
        }
    }

}

