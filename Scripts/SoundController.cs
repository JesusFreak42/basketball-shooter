using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    
    [SerializeField] private AudioSource musicSource;
    // [SerializeField] private AudioSource sfxSource;

    [SerializeField] private AudioClip music;

    private bool muted = false;
    [SerializeField] private Image muteImg;
    [SerializeField] private Sprite soundSprite;
    [SerializeField] private Sprite mutedSprite;

    private void Start(){
        PlayMusic();
        SetMute(PlayerPrefs.GetInt("soundMuted",0) == 1);
    }

    public void ToggleMute(){
        SetMute(!muted);
    }

    private void SetMute(bool m){
        muted = m;
        PlayerPrefs.SetInt("soundMuted", muted ? 1 : 0);

        if (muted){
            muteImg.sprite = mutedSprite;
            musicSource.enabled = false;
            // sfxSource.enabled = false;
        }
        else{
            muteImg.sprite = soundSprite;
            musicSource.enabled = true;
            // sfxSource.enabled = true;
        }
    }

    public void PlayMusic(){
        // if (muted) return;

        musicSource.clip = music;
        musicSource.Play();
    }

}
