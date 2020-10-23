using System.Collections.Generic;
using UnityEngine;

public enum AudioEnumType
{//顺序决定播放优先级，序号越大越优先
    BackGround,//一个个地图一个
    Skill,//一个技能三个
    Role,//人物（攻击，技能，受击），宠物（无），怪物（无）
    NPC //一个npc一个
}

public class AudioManager : AbsMonoBehaviour
{
    private static AudioManager _ins;
    public static AudioManager Ins
    {
        get
        {
            if (_ins == null)
            {
                //_ins = Singleton.getObj(typeof(AudioManager)) as AudioManager;
                _ins = new AudioManager();
                audioParent = new GameObject();
                audioParent.name = "audioParent";
                audioParent.AddComponent<AudioListener>();
                GameObject.DontDestroyOnLoad(audioParent);
            }
            return _ins;
        }
    }

    public int btnClickSoundId { get; private set; }

    //最大同时播放的声音数量
    private int _MaxAudioNum = 10;
    private List<AudioItem> _audioItemList;
    private static GameObject audioParent;

    private bool IsYinYueMute = false;
    private bool IsYinXiaoMute = false;

    public override void DoUpdate(float deltaTime)
    {
        if (_audioItemList == null || (_audioItemList != null && _audioItemList.Count==0))
        {
            return;
        }
        int i = 0;
        bool hasNpcOrRolePlaying = false;
        for (i = 0; _audioItemList!=null&&i < _audioItemList.Count; i++)
        {
            if ((_audioItemList[i].AudioEnumType == AudioEnumType.NPC ||
                 _audioItemList[i].AudioEnumType == AudioEnumType.Role)&&_audioItemList[i].IsPlaying())
            {
                hasNpcOrRolePlaying = true;
                break;
            }
        }
        for (i = 0; i < _audioItemList.Count; i++)
        {//检查播放完毕的
            //if (_audioItemList[i].AudioEnumType != AudioEnumType.BackGround &&
            //    !_audioItemList[i].IsLoading && !_audioItemList[i].IsPlaying())
            //{
            //    ClientLog.Log("_audioItemList[i].SourcePath：：" + _audioItemList[i].SourcePath);
            //    _audioItemList[i].Destroy();
            //}
            if (_audioItemList[i].AudioEnumType == AudioEnumType.BackGround && _audioItemList[i].IsPlaying())
            {
                if (hasNpcOrRolePlaying)
                {
                    _audioItemList[i].Volume = 0.2f;
                }
                else
                {
                    _audioItemList[i].Volume = 0.4f;
                }
            }
        }
    }

    /// <summary>
    /// 获得一个音源
    /// </summary>
    /// <param name="audioEnumType"></param>
    /// <returns></returns>
    private AudioItem GetUnUsingAudioSource(AudioEnumType audioEnumType)
    {
        if (_audioItemList == null)
        {
            _audioItemList = new List<AudioItem>();
        }

        int i = 0;
        for (i = 0; i < _audioItemList.Count; i++)
        {//寻找没有使用的
            if (audioEnumType == AudioEnumType.BackGround && _audioItemList[i].AudioEnumType == audioEnumType)
            {//背景音乐
                //停止播放
                _audioItemList[i].MAudioSource.Stop();
                _audioItemList[i].Destroy();
                ClientLog.Log("_audioItemList[i].SourcePath11111：：" + _audioItemList[i].SourcePath);
                return _audioItemList[i];
            }
            if (_audioItemList[i].MAudioSource.isPlaying == false && _audioItemList[i].IsLoading == false)
            {
                return _audioItemList[i];
            }
        }
        if (_audioItemList.Count < _MaxAudioNum)
        {//创建新的
            AudioItem ai = new AudioItem();
            ai.GameObject.transform.SetParent(audioParent.transform);
            _audioItemList.Add(ai);
            return ai;
        }
        for (i = 0; i < _audioItemList.Count; i++)
        {//寻找优先级低的
            if (_audioItemList[i].AudioEnumType < audioEnumType)
            {
                //停止播放
                _audioItemList[i].MAudioSource.Stop();
                _audioItemList[i].Destroy();
                ClientLog.Log("_audioItemList[i].SourcePath22222：：" + _audioItemList[i].SourcePath);
                return _audioItemList[i];
            }
        }
        return null;
    }

    public bool IsAudioPlaying(string sourcePath)
    {
        int i = 0;
        for (i = 0; _audioItemList != null && i < _audioItemList.Count; i++)
        {
            if (_audioItemList[i].SourcePath == sourcePath
                && (_audioItemList[i].IsLoading || _audioItemList[i].MAudioSource.isPlaying))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 播放声音
    /// </summary>
    /// <param name="sourcePath">声音资源名称</param>
    /// <param name="audioEnumType">声音资源类型</param>
    public void PlayAudio(string sourceName, AudioEnumType audioEnumType, float delaySecond = 0)
    {
        if (string.IsNullOrEmpty(sourceName))
        {
            return;
        }
        string sourcePath = PathUtil.Ins.GetMusicPath(sourceName, audioEnumType);
        if (IsAudioPlaying(sourcePath)) return;
        AudioItem ai = GetUnUsingAudioSource(audioEnumType);
        if (ai != null)
        {
            ai.SetData(audioEnumType, delaySecond);
            ai.PlayAudio(sourcePath);
            if (ai.AudioEnumType == AudioEnumType.BackGround)
            {
                ai.MAudioSource.mute = IsYinYueMute;
                if (sourceName == ClientConstantDef.BATTLE_BG_MUSIC_NAME)
                {
                    //战斗背景音乐 音量
                    ai.MAudioSource.volume = 0.8f;
                }
            }
            else
            {
                ai.MAudioSource.mute = IsYinXiaoMute;
            }
        }
    }

    /// <summary>
    /// 停止播放声音
    /// </summary>
    /// <param name="sourcePath">声音资源名称</param>
    /// <param name="audioEnumType">声音资源类型</param>
    public void StopAudio(string sourceName, AudioEnumType audioEnumType)
    {
        if (string.IsNullOrEmpty(sourceName))
        {
            return;
        }
        string sourcePath = PathUtil.Ins.GetMusicPath(sourceName, audioEnumType);
        int i = 0;
        for (i = 0; _audioItemList != null && i < _audioItemList.Count; i++)
        {
            if (_audioItemList[i].SourcePath == sourcePath)
            {
                _audioItemList[i].Stop();
                break;
            }
        }
    }

    public void PlatFormPlayAudio(int id)
    {
        PlatForm.Instance.PlaySound(id);
    }

    /// <summary>
    /// 设置音乐静音，true:静音，false：取消静音
    /// </summary>
    /// <param name="mute"></param>
    public void SetYinYueMute(bool mute)
    {
        IsYinYueMute = mute;
        int i = 0;
        for (i = 0; _audioItemList != null && i < _audioItemList.Count; i++)
        {
            if (_audioItemList[i].AudioEnumType == AudioEnumType.BackGround)
            {
                if (_audioItemList[i].MAudioSource != null) _audioItemList[i].MAudioSource.mute = mute;
            }
        }
    }

    /// <summary>
    /// 设置音效静音，true:静音，false：取消静音
    /// </summary>
    /// <param name="mute"></param>
    public void SetYinXiaoMute(bool mute)
    {
        IsYinXiaoMute = mute;
        int i = 0;
        for (i = 0; _audioItemList != null && i < _audioItemList.Count; i++)
        {
            if (_audioItemList[i].AudioEnumType != AudioEnumType.BackGround)
            {
                if (_audioItemList[i].MAudioSource != null) _audioItemList[i].MAudioSource.mute = mute;
            }
        }
    }

    /// <summary>
    /// 暂时设置静音
    /// </summary>
    /// <param name="mute"></param>
    public void SetMuteTmp(AudioEnumType audioType,bool mute)
    {
        int i = 0;
        if (mute)
        {
            for (i = 0; i < _audioItemList.Count; i++)
            {
                if (audioType == _audioItemList[i].AudioEnumType)
                {
                    _audioItemList[i].MAudioSource.mute = true;
                }
            }
        }
        else
        {
            for (i = 0; i < _audioItemList.Count; i++)
            {
                if (audioType == _audioItemList[i].AudioEnumType)
                {
                    if (_audioItemList[i].AudioEnumType == AudioEnumType.BackGround)
                    {
                        _audioItemList[i].MAudioSource.mute = IsYinYueMute;
                    }
                    else
                    {
                        _audioItemList[i].MAudioSource.mute = IsYinXiaoMute;
                    }
                }
            }
        }
    }

    /// <summary>
    /// 暂时设置静音
    /// </summary>
    /// <param name="mute"></param>
    public void SetAllMuteTmp(bool mute)
    {
        int i = 0;
        if (mute)
        {
            for (i = 0; i < _audioItemList.Count; i++)
            {
                _audioItemList[i].MAudioSource.mute = true;
            }
        }
        else
        {
            for (i = 0; i < _audioItemList.Count; i++)
            {
                if (_audioItemList[i].AudioEnumType == AudioEnumType.BackGround)
                {
                    _audioItemList[i].MAudioSource.mute = IsYinYueMute;
                }
                else
                {
                    _audioItemList[i].MAudioSource.mute = IsYinXiaoMute;
                }
            }
        }
    }

    /// <summary>
    /// 设置音量
    /// </summary>
    /// <param name="volume"></param>
    public void SetVolume(float volume)
    {
        int i = 0;
        for (i = 0; i < _audioItemList.Count; i++)
        {
            _audioItemList[i].MAudioSource.volume = volume;
        }
    }
    /// <summary>
    /// 回收所有音效
    /// </summary>
    public void DestroyAll()
    {
        if (_audioItemList != null)
        {
            int len = _audioItemList.Count;
            for (int i = 0; i < len; i++)
            {
                _audioItemList[i].Destroy(true);
            }
            _audioItemList.Clear();
            _audioItemList = null;
        }
    }

    public void LoadPlatfromSound()
    {
        btnClickSoundId = platformLoadSound("buttonclick.wav");
    }

    private int platformLoadSound(string name)
    {
        return PlatForm.Instance.LoadSound(name);
    }
}

class AudioItem
{
    private GameObject _gameObject;
    private AudioSource _mAudioSource;
    private string _sourcePath;
    private AudioEnumType _audioEnumType;
    private bool _loop;
    private bool _isLoading;
    private float _volume;
    private bool isStoped;
    /// <summary>
    /// 延迟播放时间，单位秒
    /// </summary>
    private float _delaySecond;

    public AudioItem()
    {
        _gameObject = new GameObject();
        GameObject.name = "audioSource";
        _mAudioSource = GameObject.AddComponent<AudioSource>();
        _mAudioSource.playOnAwake = false;
    }

    public void Destroy(bool destroyObj = false)
    {
        _mAudioSource.Stop();
        SourceManager.Ins.removeReference(_sourcePath);
        _sourcePath = null;
        if (destroyObj)
        {
            GameObject.DestroyImmediate(_mAudioSource, true);
            _mAudioSource = null;
            GameObject.DestroyImmediate(_gameObject, true);
            _gameObject = null;
        }
    }

    public AudioSource MAudioSource
    {
        get { return _mAudioSource; }
        //set { _audioSource = value; }
    }

    public void SetData(AudioEnumType audiotype, float DelaySecond = 0)
    {
        AudioEnumType = audiotype;
        _delaySecond = DelaySecond;
    }

    public void PlayAudio(string audioPath)
    {
        SourcePath = audioPath;
    }

    public string SourcePath
    {
        get { return _sourcePath; }
        private set
        {
            if (_sourcePath != null)
            {
                SourceManager.Ins.removeReference(_sourcePath);
            }
            if (string.IsNullOrEmpty(value))
            {
                return;
            }
            isStoped = false;
            _sourcePath = value;
            if (SourceManager.Ins.hasAssetBundle(_sourcePath))
            {
                _isLoading = false;
                loadComplete(null);
            }
            else
            {
                _isLoading = true;
                SourceLoader.Ins.load(_sourcePath, loadComplete);
            }
        }
    }

    private void loadComplete(RMetaEvent e)
    {
        AudioClip ab = SourceManager.Ins.GetAsset<AudioClip>(_sourcePath);
        if (ab != null && MAudioSource!=null&&!isStoped)
        {
            MAudioSource.clip = ab;
            MAudioSource.volume = _volume;
            MAudioSource.PlayDelayed(_delaySecond);
            AudioManager.Ins.SetAllMuteTmp(false);
            if (AudioEnumType == AudioEnumType.BackGround)
            {
                SourceManager.Ins.ignoreDispose(_sourcePath);
            }
            isStoped = false;
        }
        _isLoading = false;
    }

    public AudioEnumType AudioEnumType
    {
        get { return _audioEnumType; }
        set
        {
            _audioEnumType = value;
            switch (_audioEnumType)
            {
                case AudioEnumType.BackGround:
                    Loop = true;
                    Volume = 0.4f;
                    break;
                case AudioEnumType.Skill:
                    Loop = false;
                    Volume = 0.6f;
                    break;
                case AudioEnumType.Role:
                    Loop = false;
                    Volume = 1f;
                    break;
                case AudioEnumType.NPC:
                    Loop = false;
                    Volume = 1f;
                    break;
                default:
                    Loop = false;
                    Volume = 1f;
                    break;
            }
        }
    }

    public bool Loop
    {
        get { return _loop; }
        set
        {
            _loop = value;
            MAudioSource.loop = _loop;
        }
    }

    public float Volume
    {
        get { return _volume; }
        set
        {
            _volume = value;
            MAudioSource.volume = _volume;
        }
    }

    public bool IsLoading
    {
        get { return _isLoading; }
    }

    public GameObject GameObject
    {
        get { return _gameObject; }
    }

    public bool IsPlaying()
    {
        return _mAudioSource.isPlaying;
    }

    public void Stop()
    {
        isStoped = true;
        _mAudioSource.Stop();
    }

    public void Pause()
    {
        _mAudioSource.Pause();
    }

    public void UnPause()
    {
        _mAudioSource.UnPause();
    }
}

