using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MFramework
{
    public class Res : SimpleRC
    {
        public Object Asset { get; private set; }

        public string Name { get { return Asset.name; } }

        public Res(Object asset)
        {
            Asset = asset;
        }

        protected override void OnZeroRef()
        {
            Resources.UnloadAsset(Asset);
            ResourceLoader.SharedLoadedRes.Remove(this);
            Asset = null;
        }
    }

}