using BetaFramework;
using UnityEngine;

public class AudioSourceData : MonoBehaviour
{
    // Use this for initialization
    public AudioSource m_Source;

    public void play(AudioClip clip)
    {
        m_Source.PlayOneShot(clip);
        Timer.Schedule(this, clip.length, () =>
        {
            AppEngine.SObjectPoolManager.Despawn<Transform>(transform);
        });
    }
}