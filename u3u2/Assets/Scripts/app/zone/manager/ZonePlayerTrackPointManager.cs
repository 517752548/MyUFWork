using UnityEngine;
using app.model;
using app.utils;

namespace app.zone
{
    public class ZonePlayerTrackPointManager
    {
        private class ZonePlayerTrackPoint
        {
            private GameObject mContainer = null;
            private GameObject mTrackPoint = null;
            private bool mIsShown = false;
            private float mLifeTime = 0.0f;

            public ZonePlayerTrackPoint()
            {
                mContainer = new GameObject("TrackPoint");
                mContainer.transform.SetParent(SceneModel.ins.zoneModelContainer.transform);
                mTrackPoint = SourceManager.Ins.createObjectFromAssetBundle(PathUtil.Ins.GetEffectPath(ClientConstantDef.CLICK_GROUND_EFFECT_NAME));
                mTrackPoint.transform.SetParent(mContainer.transform);
                GameObjectUtil.SetLayer(mContainer, SceneModel.ins.zoneModelContainer.layer);
                mTrackPoint.transform.localPosition = Vector3.zero;
                mTrackPoint.transform.localScale = Vector3.one;
                mTrackPoint.transform.localEulerAngles = Vector3.zero;
                mTrackPoint.SetActive(true);
                mIsShown = true;
            }

            public void Show(Vector3 position)
            {
                if (!mIsShown)
                {
                    mContainer.transform.localPosition = position;
                    mContainer.SetActive(true);
                    mIsShown = true;
                    mLifeTime = 0.0f;
                    Update();
                }
            }

            public void Hide()
            {
                if (mIsShown)
                {
                    mContainer.SetActive(false);
                    mIsShown = false;
                }
            }

            public void Update()
            {
                if (mIsShown)
                {
                    mTrackPoint.transform.localPosition = ZoneUtil.GetFixedPosition(mContainer.transform);
                    mLifeTime += Time.deltaTime;
                    if (mLifeTime > 3.0f)
                    {
                        Hide();
                    }
                }
            }
            
            public void Destroy()
            {
                GameObject.DestroyImmediate(mContainer, true);
                mContainer = null;
            }

        }

        private ZonePlayerTrackPoint[] mTrackPoints = new ZonePlayerTrackPoint[5];
        private int mCurIdx = 0;
        private static ZonePlayerTrackPointManager mIns = null;
        
        public static ZonePlayerTrackPointManager ins
        {
            get
            {
                if (mIns == null)
                {
                    mIns = new ZonePlayerTrackPointManager();
                }
                return mIns;
            }
        }

        public void Init()
        {
            for (int i = 0; i < 5; i++)
            {
                if (mTrackPoints[i] != null)
                {
                    mTrackPoints[i].Destroy();
                    mTrackPoints[i] = null;
                }
            }
            
            for (int i = 0; i < 5; i++)
            {
                ZonePlayerTrackPoint trackPoint = new ZonePlayerTrackPoint();
                trackPoint.Hide();
                mTrackPoints[i] = trackPoint;
            }
            mCurIdx = 0;
        }

        public void ShowOne(Vector3 position)
        {
            if (mTrackPoints[mCurIdx] == null)
            {
                mTrackPoints[mCurIdx] = new ZonePlayerTrackPoint();
            }
            mTrackPoints[mCurIdx].Hide();
            mTrackPoints[mCurIdx].Show(position);
            mCurIdx++;
            if (mCurIdx == 5)
            {
                mCurIdx = 0;
            }
        }

        public void HideAll()
        {
			for (int i = 0; i < 5; i++)
            {
                if (mTrackPoints[i] != null)
                {
                    mTrackPoints[i].Hide();
                }
            }
        }

        public void Update()
        {
			for (int i = 0; i < 5; i++)
            {
                mTrackPoints[i].Update();
            }
        }
    }
}