using System;
using app.state;
using UnityEngine;
using app.model;
using app.story;

namespace app.zone
{
    public class ZoneCameraManager
    {
        
        private float mShakeStartTime = 0.0f;
        private float mShakeTime = 0.0f;
        private bool mIsShaking = false;
        private int mLastShakeStamp = 0;
        
        private static ZoneCameraManager mIns = new ZoneCameraManager();

        public static ZoneCameraManager ins
        {
            get
            {
                return mIns;
            }
        }

        public ZoneCameraManager()
        {
            if (ZoneCameraManager.ins != null)
            {
                throw new Exception("ZoneCameraManager instance already exists!");
            }
        }

        public void Update(Vector3 selfPos, bool useTween = true)
        {
            if (StateManager.Ins.getCurState().state == StateDef.storyState
                &&StoryManager.ins.IsStoryBattle)
            {
                return;
            }
            GameObject camsContainer = SceneModel.ins.zoneCamsContainer;
            //ZoneCharacter self = ZoneCharacterManager.ins.self;

            if (camsContainer == null/* || self == null*/)
            {
                return;
            }

            float camHalfW = ZoneModel.ins.viewportWidth / 2f;
            float camHalfH = ZoneModel.ins.viewportHeight / 2f;
            float mapHalfW = (float)ZoneModel.ins.mapPixelWidth / (float)ZoneDef.MAP_PIXEL_ONE_UNIT / 2f;
            float mapHalfH = (float)ZoneModel.ins.mapPixelHeight / (float)ZoneDef.MAP_PIXEL_ONE_UNIT / 2f;
            Vector3 camCurPos = camsContainer.transform.localPosition;
            //Vector3 playerPos = self.localPosition;

            //mGroundCam.transform.localPosition = camPos;
            //mCoverCam.transform.localPosition = camPos;
            //mChaCam.transform.localPosition = playerPos;

            Vector3 camTargetPos = GetCamPos(camHalfW, camHalfH, mapHalfW, mapHalfH, selfPos);
            camTargetPos.y = camCurPos.y;

            if (camTargetPos != camCurPos)
            {
                if (useTween)
                {
                    Vector3 smmothTargetPos = camCurPos + ((camTargetPos - camCurPos) * 0.05f * (Time.deltaTime / Time.fixedDeltaTime));
                    if (Vector3.Distance(smmothTargetPos, camTargetPos) > 0.5f)
                    {
                        camTargetPos = camTargetPos + Vector3.Normalize(smmothTargetPos - camTargetPos) * 0.5f;
                    }
                    else if (Vector3.Distance(smmothTargetPos, camTargetPos) > 0.01f)
                    {
                        camTargetPos = smmothTargetPos;
                    }
                }
                camsContainer.transform.localPosition = camTargetPos;
            }

            if (mIsShaking)
            {
                if (Time.time - mShakeStartTime >= mShakeTime)
                {
                    SceneModel.ins.zoneGroundCam.transform.localPosition = Vector3.zero;
                    SceneModel.ins.zone3DModelCam.transform.localPosition = Vector3.zero;
                    mIsShaking = false;
                }
                else
                {
                    if (mLastShakeStamp >= 2)
                    {
                        float x = UnityEngine.Random.Range(-0.06f, 0.06f);
                        float z = UnityEngine.Random.Range(-0.06f, 0.06f);
                        Vector3 v = new Vector3(x, 0, z);
                        SceneModel.ins.zoneGroundCam.transform.localPosition = v;
                        SceneModel.ins.zone3DModelCam.transform.localPosition = v;
                        mLastShakeStamp = 0;
                    }
                    mLastShakeStamp++;
                }
            }
        }

        public void SetCameraPos(Vector3 viewportCenter)
        {
            float camHalfW = ZoneModel.ins.viewportWidth / 2f;
            float camHalfH = ZoneModel.ins.viewportHeight / 2f;
            float mapHalfW = (float)ZoneModel.ins.mapPixelWidth / (float)ZoneDef.MAP_PIXEL_ONE_UNIT / 2f;
            float mapHalfH = (float)ZoneModel.ins.mapPixelHeight / (float)ZoneDef.MAP_PIXEL_ONE_UNIT / 2f;

            GameObject camsContainer = SceneModel.ins.zoneCamsContainer;

            camsContainer.transform.localPosition = GetCamPos(camHalfW, camHalfH, mapHalfW, mapHalfH, viewportCenter);
        }

        public void Shake(float seconds)
        {
            mShakeTime = seconds;
            mShakeStartTime = Time.time;
            mIsShaking = true;
        }

        private Vector3 GetCamPos(float camHalfW, float camHalfH, float mapHalfW, float mapHalfH, Vector3 playerPos)
        {
            Vector3 camPos;
            if (playerPos.x >= 0)
            {
                if (playerPos.x + camHalfW <= mapHalfW)
                {
                    camPos.x = playerPos.x;
                }
                else
                {
                    camPos.x = mapHalfW - camHalfW;
                }
            }
            else
            {
                if (playerPos.x - camHalfW >= -mapHalfW)
                {
                    camPos.x = playerPos.x;
                }
                else
                {
                    camPos.x = camHalfW - mapHalfW;
                }
            }

            if (playerPos.z >= 0)
            {
                if (playerPos.z + camHalfH <= mapHalfH)
                {
                    camPos.z = playerPos.z;
                }
                else
                {
                    camPos.z = mapHalfH - camHalfH;
                }
            }
            else
            {
                if (playerPos.z - camHalfH >= -mapHalfH)
                {
                    camPos.z = playerPos.z;
                }
                else
                {
                    camPos.z = camHalfH - mapHalfH;
                }
            }

            camPos.y = playerPos.y;
            return camPos;
        }

        public void FixedUpdate()
        {

        }

        public Texture2D ScreenShot(Camera[] cams, int width,int height)
        {  
            int camsLen = cams.Length;
            RenderTexture rt = new RenderTexture(width, height, 0, RenderTextureFormat.RGB565, RenderTextureReadWrite.Linear);
            for (int i = 0; i < camsLen; i++)
            {
                cams[i].targetTexture = rt;
                cams[i].Render();
            }
            RenderTexture.active = rt;
            Texture2D screenShot = new Texture2D((int)(width), (int)(height), TextureFormat.RGB24, false, true);  
            screenShot.ReadPixels(new Rect(0, 0, width, height), 0, 0);  
            screenShot.Apply();
            for (int i = 0; i < camsLen; i++)
            {
                cams[i].targetTexture = null;
            }
            RenderTexture.active = null;  
            UnityEngine.Object.Destroy(rt);
            return screenShot;
            /*
            byte[] bytes = screenShot.EncodeToPNG();  
            string filename = Application.dataPath + "/Img"  
                + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + UnityEngine.Random.Range(0.0f, 10.0f) + ".png";  
            System.IO.File.WriteAllBytes(filename, bytes);  
            Debug.LogError(filename);
            */
        }  
    }
}