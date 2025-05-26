using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    
    [SerializeField] private AudioSource musicSource;
    // [SerializeField] private AudioSource sfxSource; //we'll use this if we want to add sound effects in the future

    [SerializeField] private AudioClip music; //the music clip

    private bool muted = false; //whether the game sound is muted
    [SerializeField] private Image muteImg; //the muted/unmuted UI image
    [SerializeField] private Sprite soundSprite; //unmuted sprite
    [SerializeField] private Sprite mutedSprite; //muted sprite

    private void Start(){
        PlayMusic(); //initially play music
        SetMute(PlayerPrefs.GetInt("soundMuted",0) == 1); //set the muted state based on saved player pref, defaulting to unmuted if no saved pref
    }

    public void ToggleMute(){
        SetMute(!muted);
    }

    private void SetMute(bool m){
        muted = m;
        PlayerPrefs.SetInt("soundMuted", muted ? 1 : 0); //save the muted state in player prefs

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
        musicSource.clip = music; //set the music clip to play
        musicSource.Play(); //play said music clip
    }

}
