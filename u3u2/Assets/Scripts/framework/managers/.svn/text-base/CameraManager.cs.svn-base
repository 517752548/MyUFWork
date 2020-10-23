using System.Collections.Generic;
using UnityEngine;

public class CameraManager
{
    private static CameraManager mIns = null;
    private List<GameObject> mCams = new List<GameObject>();
    public static CameraManager Ins
    {
        get
        {
            if (mIns == null) mIns = new CameraManager();
            return mIns;
        }
    }

    public void AddCamera(GameObject camera)
    {
        if (mCams.Contains(camera)) return;
        mCams.Add(camera);
    }

    public void RemoveCamera(GameObject camera)
    {
        mCams.Remove(camera);
    }

    public GameObject GetCamera(string name)
    {
        int _len = mCams.Count;
        for (int _i = 0; _i < _len; _i++)
        {
            if (mCams[_i] != null && mCams[_i].name == name)
            {
                return mCams[_i];
            }
        }

        GameObject cam = GameObject.Find(name);
        if (cam != null) mCams.Add(cam);
        return cam;
    }
}