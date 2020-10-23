using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using app.utils;
using UnityEngine;
/// <summary>
/// 特效工具类，显示特效
/// </summary>
public class EffectUtil : AbsMonoBehaviour
{
    private static EffectUtil _ins;
    public static EffectUtil Ins
    {
        get
        {
            if (_ins == null)
            {
                //_ins = Singleton.getObj(typeof (EffectUtil)) as EffectUtil;
                _ins = new EffectUtil();
            }
            return _ins;
        }
    }

    private Dictionary<string, EffectInfo> effectObjDic;
    private void initDic()
    {
        if (effectObjDic == null)
        {
            effectObjDic = new Dictionary<string, EffectInfo>();
        }
    }

    public void PlayEffect(string effectName, int uilayer, bool loop, GameObject parentgo, Vector3 effectPos = default(Vector3))
    {
        initDic();
        EffectInfo go = null;
        if (effectObjDic.ContainsKey(effectName))
        {
            effectObjDic.TryGetValue(effectName, out go);
        }
        if (go == null)
        {
            go = new EffectInfo();
            go.effectname = effectName;
            go.effectPos = effectPos;
            go.UIlayer = uilayer;
            go.loop = loop;
            go.parentGo = parentgo;
            if (SourceManager.Ins.hasAssetBundle(PathUtil.Ins.GetEffectPath(effectName)))
            {
                showEffect(go);
            }
            else
            {
                SourceManager.Ins.ignoreDispose(PathUtil.Ins.GetEffectPath(effectName));
                SourceLoader.Ins.load(PathUtil.Ins.GetEffectPath(effectName), loadComplete, null, go, true);
            }
        }
        else
        {
            /*
            if (go.go != null && go.go.gameObject.activeInHierarchy)
            {
                //已经在播放了
                go.go.SetActive(false);
                go.go.SetActive(true);
            }
            else
            {
                showEffect(go);
            }
            */
            go.effectname = effectName;
            go.effectPos = effectPos;
            go.UIlayer = uilayer;
            go.loop = loop;
            go.parentGo = parentgo;
            showEffect(go);
        }
    }

    private void loadComplete(RMetaEvent e)
    {
        LoadInfo go = e.data as LoadInfo;
        showEffect(go.param as EffectInfo);
    }

    private void showEffect(EffectInfo go)
    {
        if (go.go == null)
        {
            go.go = SourceManager.Ins.createObjectFromAssetBundle(PathUtil.Ins.GetEffectPath(go.effectname));
        }
        else
        {
            go.go.SetActive(false);
        }
        go.go.SetActive(true);
        if (go.parentGo != null)
        {
            go.go.transform.SetParent(go.parentGo.transform);
        }
        else
        {
            Canvas canvasobj = UGUIConfig.GetCanvasByWndType(LayerConfig.getWndTypeByLayer(go.UIlayer));
            go.go.transform.SetParent(canvasobj.transform);
        }

        //go.go.transform.localEulerAngles = new Vector3(0, 315, 0);
        go.go.transform.localPosition = go.effectPos;
        GameObjectUtil.SetLayer(go.go, go.UIlayer);

        //go.startPlayTime = DateTime.Now;
        //go.Playtime = GetMaxEffectTime(go.go);
        if (!effectObjDic.ContainsKey(go.effectname))
        {
            effectObjDic.Add(go.effectname, go);
        }
    }

    /*
    public override void DoUpdate(float deltaTime)
    {
        base.DoUpdate(deltaTime);
        if (effectObjDic == null || (effectObjDic != null && effectObjDic.Count==0)) { return; }
        IDictionaryEnumerator enumerator = this.effectObjDic.GetEnumerator();
        List<string> removeEffectName = new List<string>();
        while (enumerator.MoveNext())
        {
            EffectInfo effectInfo = ((EffectInfo)enumerator.Value);
            TimeSpan ts = DateTime.Now - effectInfo.startPlayTime;
            if (effectInfo.Playtime != 0 && ts.TotalSeconds > effectInfo.Playtime)
            {
                if (!effectInfo.loop)
                {
                    effectInfo.go.SetActive(false);
                    SourceManager.Ins.unignoreDispose(PathUtil.Ins.GetEffectPath(effectInfo.effectname));
                    SourceManager.Ins.removeReference(PathUtil.Ins.GetEffectPath(effectInfo.effectname), effectInfo.go);
                    removeEffectName.Add(effectInfo.effectname);
                }
            }
        }
        for (int i=0;i<removeEffectName.Count;i++)
        {
            effectObjDic.Remove(removeEffectName[i]);
        }
    }
    */
    /// <summary>
    /// 移除特效
    /// </summary>
    /// <param name="effectName"></param>
    public void RemoveEffect(string effectName)
    {
        EffectInfo go = null;
        if (effectObjDic != null && effectObjDic.ContainsKey(effectName))
        {
            effectObjDic.TryGetValue(effectName, out go);
        }
        if (go != null)
        {
            if (go.go != null)
            {
                go.go.SetActive(false);
            }
            SourceManager.Ins.unignoreDispose(PathUtil.Ins.GetEffectPath(effectName));
            SourceManager.Ins.removeReference(PathUtil.Ins.GetEffectPath(effectName), go.go);
            go.go = null;
            effectObjDic.Remove(effectName);
        }
    }

    public void Clear()
    {
        if (effectObjDic != null)
        {
            string[] effectNames = effectObjDic.Keys.ToArray();
            int len = effectNames.Length;
            for (int i = 0; i < len; i++)
            {
                RemoveEffect(effectNames[i]);
            }
            effectObjDic.Clear();
        }
    }

    /*public float GetMaxEffectTime(GameObject go)
      {
          if (go==null)
          {
              return 0;
          }
          float maxtime = 0;
          ParticleSystem[] ps = go.GetComponentsInChildren<ParticleSystem>();
          for (int i = 0; ps!=null&&i < ps.Length; i++)
          {
              if (ps[i].startDelay+ps[i].startLifetime>maxtime)
              {
                  maxtime = ps[i].startDelay + ps[i].startLifetime;
              }
          }
          Animator[] anim = go.GetComponentsInChildren<Animator>();
          for (int i = 0; anim!=null&&i < anim.Length; i++)
          {
              AnimationClip[] clips = anim[i].runtimeAnimatorController.animationClips;
              for (int j = 0; clips!=null&&j < clips.Length; j++)
              {
                  if (clips[j].averageDuration > maxtime)
                  {
                      maxtime = clips[j].averageDuration;
                  }
              }
          }
          return maxtime;
      }
       * */
}

class EffectInfo
{
    public GameObject go;
    public string effectname;
    public Vector3 effectPos;
    public int UIlayer;
    public bool loop;
    public GameObject parentGo;
    //public DateTime startPlayTime;
    //单位s
    //private float playtime;

    /*public float Playtime
    {
        set
        {
            if (value == 0)
            {
                ClientLog.LogError("动画播放时间为0！"+effectname);
            }
            playtime = value;
        }
        get { return playtime; }
    }
    */
}
