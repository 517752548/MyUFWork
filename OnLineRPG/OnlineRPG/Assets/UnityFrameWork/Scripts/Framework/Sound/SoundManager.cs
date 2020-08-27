using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace BetaFramework
{
    public class SoundManager : IModule
    {
        private GameObject m_RootGO;
        private GameObject m_UsedGO;
        private GameObject m_UnusedGO;
        private float m_BGMVolume;
        private float m_SFXVolume;
        private bool m_BGMEnable;
        private bool m_SFXEnable;
        private bool m_BGMPause;
        private AudioSource m_MusicAudioSource;
        private Dictionary<string, AudioClip> m_AudioClips;
        private Dictionary<string, List<GameObject>> m_UnusedPool;
        private Dictionary<string, List<GameObject>> m_UsedPool;
        private string currentBGName;

        public SoundManager()
        {
            m_RootGO = new GameObject("POOL:AUDIO");
            m_UsedGO = new GameObject("USED");
            m_UsedGO.transform.parent = m_RootGO.transform;
            m_UnusedGO = new GameObject("UNUSED");
            m_UnusedGO.transform.parent = m_RootGO.transform;

            Object.DontDestroyOnLoad(m_RootGO);

            m_BGMVolume = 1;
            m_SFXVolume = 1;
            m_BGMEnable = true;
            m_SFXEnable = true;
            m_AudioClips = new Dictionary<string, AudioClip>();
            m_UnusedPool = new Dictionary<string, List<GameObject>>();
            m_UsedPool = new Dictionary<string, List<GameObject>>();
        }

        private AudioSource GetFromPool(string audioType)
        {
            List<GameObject> audioUnusedGOs = null;
            if (!m_UnusedPool.ContainsKey(audioType))
            {
                audioUnusedGOs = new List<GameObject>();
                m_UnusedPool.Add(audioType, audioUnusedGOs);
            }
            else
            {
                audioUnusedGOs = m_UnusedPool[audioType];
            }

            List<GameObject> audioUsedGOs = null;
            if (!m_UsedPool.ContainsKey(audioType))
            {
                audioUsedGOs = new List<GameObject>();
                m_UsedPool.Add(audioType, audioUsedGOs);
            }
            else
            {
                audioUsedGOs = m_UsedPool[audioType];
            }

            AudioSource audioSource = null;
            GameObject audioGO = null;
            audioUnusedGOs = m_UnusedPool[audioType];
            if (audioUnusedGOs.Count > 0)
            {
                audioGO = audioUnusedGOs[0];
                audioSource = audioGO.GetComponent<AudioSource>();
                audioUnusedGOs.RemoveAt(0);
            }
            else
            {
                audioGO = new GameObject(audioType);
                audioSource = audioGO.AddComponent<AudioSource>();
            }

            audioGO.transform.parent = m_UsedGO.transform;
            audioUsedGOs.Add(audioGO);
            return audioSource;
        }

        private void PutToPool(GameObject go)
        {
            List<GameObject> audioUsedGOs = m_UsedPool[go.name];
            audioUsedGOs.Remove(go);

            List<GameObject> audioUnusedGOs = m_UnusedPool[go.name];
            audioUnusedGOs.Add(go);
            go.transform.parent = m_UnusedGO.transform;
        }

        public float BgmVolume
        {
            get { return m_BGMVolume; }
            set
            {
                m_BGMVolume = Mathf.Clamp(value, 0f, 1f);
                if (m_MusicAudioSource != null)
                {
                    m_MusicAudioSource.volume = m_BGMVolume;
                }
            }
        }

        public float SfxVolume
        {
            get { return m_SFXVolume; }
            set { m_SFXVolume = Mathf.Clamp(value, 0f, 1f); }
        }

        public bool BgmEnable
        {
            get { return m_BGMEnable; }
            set
            {
                m_BGMEnable = value;

                if (m_MusicAudioSource != null)
                {
                    if (m_BGMEnable)
                        m_MusicAudioSource.Play();
                    else
                        m_MusicAudioSource.Stop();
                }
            }
        }

        public bool BGMPlaying
        {
            get
            {
                if (m_MusicAudioSource != null)
                {
                    return true;
                }

                return false;
            }
        }

        public bool IsPuase
        {
            get { return m_BGMPause; }
        }

        public void BgmPause()
        {
            if (!AppEngine.SGameSettingManager.Music.Value)
            {
                return;
            }

            BgmVolume = 0;
            m_BGMPause = true;
            if (m_MusicAudioSource)
                m_MusicAudioSource.Pause();
        }

        public void BgmUnPause()
        {
            if (!AppEngine.SGameSettingManager.Music.Value)
            {
                return;
            }

            m_BGMPause = false;
            BgmVolume = 1;
            if (m_MusicAudioSource)
            {
                m_MusicAudioSource.UnPause();
                m_MusicAudioSource.DOFade(1, 2f);
            }
        }

        public bool SfxEnable
        {
            get { return m_SFXEnable; }
            set { m_SFXEnable = value; }
        }

        public async Task<int> LoadAudioClip(string audioType)
        {
            if (!m_AudioClips.ContainsKey(audioType))
            {
                AudioClip clip = await Addressables.LoadAssetAsync<AudioClip>(audioType).Task;
                if (clip)
                {
                    if (!m_AudioClips.ContainsKey(audioType))
                    {
                        m_AudioClips.Add(audioType, clip);
                    }

                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 1;
            }
        }

        public async void PlayBGM(string audioType)
        {
            if (!AppEngine.SGameSettingManager.Music.Value)
            {
                return;
            }

            int id = await LoadAudioClip(audioType);
            if (id == 0)
            {
                return;
            }
            

            if (m_MusicAudioSource == null)
            {
                AudioSource poolAudio = GetFromPool(audioType);
                m_MusicAudioSource = poolAudio;
                m_MusicAudioSource.loop = true;
            }

            m_MusicAudioSource.gameObject.name = audioType;
            m_MusicAudioSource.volume = m_BGMVolume;
            if (m_AudioClips.ContainsKey(audioType))
            {
                m_MusicAudioSource.clip = m_AudioClips[audioType];
                if (m_BGMEnable)
                {
                    m_MusicAudioSource.Play();
                }
            }

            currentBGName = audioType;
        }

        public async void PlaySFX(string audioType)
        {
            if (!AppEngine.SGameSettingManager.Sound.Value)
            {
                return;
            }

            if (m_SFXEnable)
            {
                await LoadAudioClip(audioType);
                AudioSource audioSource = GetFromPool("audio");
                audioSource.volume = m_SFXVolume;
                audioSource.clip = m_AudioClips[audioType];
                audioSource.Play();
            }
        }

        public override void Execute(float deltaTime)
        {
            foreach (KeyValuePair<string, List<GameObject>> pair in m_UsedPool)
            {
                List<GameObject> list = pair.Value;
                GameObject go = null;

                for (int i = 0; i < list.Count; i++)
                {
                    go = list[i];
                    AudioSource audioSource = go.GetComponent<AudioSource>();
                    if (!audioSource.isPlaying && audioSource != m_MusicAudioSource)
                    {
                        PutToPool(go);
                    }
                }
            }
        }

        public override void Shut()
        {
            m_AudioClips.Clear();
            foreach (KeyValuePair<string, List<GameObject>> pair in m_UnusedPool)
            {
                List<GameObject> list = pair.Value;
                GameObject go = null;

                for (int i = 0; i < list.Count; i++)
                {
                    go = list[i];
                    //go.transform.parent = null;
                    GameObject.Destroy(go);
                }
            }

            m_UnusedPool.Clear();
            foreach (KeyValuePair<string, List<GameObject>> pair in m_UsedPool)
            {
                List<GameObject> list = pair.Value;
                GameObject go = null;

                for (int i = 0; i < list.Count; i++)
                {
                    go = list[i];
                    //go.transform.parent = null;
                    GameObject.Destroy(go);
                }
            }

            m_UsedPool.Clear();
            m_MusicAudioSource = null;

            GameObject.Destroy(m_RootGO);
        }
    }
}