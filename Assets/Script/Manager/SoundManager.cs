using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager
{
    private static SoundManager instance = null;

    private SoundManager()
    {
    }

    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SoundManager();
            }
            return instance;
        }
    }

    public enum EnumSound
    {
        spaceHit,
        extincteur,
        hammer,
        menuSelectionSound,
        welder,
        wrench,
        PlayerMove,
    }

    private static Dictionary<EnumSound, float> soundTimerDictionary;
    private static GameObject oneShotGameObject;
    private static AudioSource oneShotAudioSource;
    public static void Initialize()
    {
        soundTimerDictionary = new Dictionary<EnumSound, float>();
        soundTimerDictionary[EnumSound.PlayerMove] = 0f;
    }


    public static void PlaySound(EnumSound sound)
    {
        if (CanPlaySound(sound))
        {
            if (oneShotGameObject == null)
            {
                oneShotGameObject = new GameObject("One shot sound");
                oneShotAudioSource = oneShotGameObject.AddComponent<AudioSource>();
            }

            oneShotAudioSource.PlayOneShot(GetAudioClip(sound));
        }
    }
    //this is a 3d sound
    public static void PlaySound(EnumSound sound, Vector3 position)
    {
        if (CanPlaySound(sound))
        {
            GameObject soundGameObject = new GameObject("Sound");
            soundGameObject.transform.position = position;
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.clip = GetAudioClip(sound);
            audioSource.maxDistance = 100f;
            audioSource.spatialBlend = 1f;
            audioSource.rolloffMode = AudioRolloffMode.Linear;
            audioSource.dopplerLevel = 0f;
            audioSource.Play();
            //getting the length of the audio clip for delete
            Object.Destroy(soundGameObject, audioSource.clip.length);
        }
    }

    private static bool CanPlaySound(EnumSound sound)
    {
        switch (sound)
        {
            default:
                return true;
            case EnumSound.PlayerMove:
                if (soundTimerDictionary.ContainsKey(sound))
                {
                    float lastTimePlayed = soundTimerDictionary[sound];
                    float playerMoveTimerMax = .15f;
                    if (lastTimePlayed + playerMoveTimerMax < Time.time)
                    {
                        soundTimerDictionary[sound] = Time.time;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
        }
    }

    private static AudioClip GetAudioClip(EnumSound sound)
    {
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipArray)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }
        Debug.LogError("Sound " + sound + " not found!");
        return null;
    }

    public static void AddButtonSounds()
    {

    }

}
