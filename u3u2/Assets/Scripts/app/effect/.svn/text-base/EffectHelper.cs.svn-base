using System.Text;
using UnityEngine;
using app.model;

namespace app.effect
{
    public class EffectHelper
    {
        public EffectHelper()
        {
        }

        public static EffectBase CreateEffectBase(string effectPath)
        {
            ICacheable ic = MemCache.FetchFreeCache(effectPath, MemCacheType.EFFECT);
            if (ic == null)
            {
                EffectBase e = new EffectBase();
                e.SetDisplayModel(effectPath);
                MemCache.Cache(e);
                e.Use();
                return e;
            }
            ic.Use();
            return (EffectBase)ic;
        }
    }
}