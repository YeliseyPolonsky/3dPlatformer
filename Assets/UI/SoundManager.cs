using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _music;
    
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }
    
    public void SetMusicEnabled(bool isEnabled)
    {
        _music.enabled = isEnabled;
    }
}
