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
    GameAssets ga;

    private static Dictionary<EnumSound, float> soundTimerDictionary;
    private static GameObject oneShotGameObject;
    private static AudioSource oneShotAudioSource;
    public static void Initialize()
    {
        soundTimerDictionary = new Dictionary<EnumSound, float>();
        soundTimerDictionary[EnumSound.PlayerMove] = 0f;
    }


    public void PlaySound(EnumSound sound)
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

    /*public void PlaySound(EnumSound sound)
    {
        ga = (GameObject.Instantiate(Resources.Load("Prefabs/GameAssets")) as GameObject).GetComponent<GameAssets>();
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        switch (sound)
        {
            case EnumSound.spaceHit:
                audioSource.PlayOneShot(GameAssets.i.spaceHit);
                break;
            case EnumSound.extincteur:
                audioSource.PlayOneShot(GameAssets.i.extincteur);
                break;
            case EnumSound.hammer:
                audioSource.PlayOneShot(GameAssets.i.hammer);
                break;
            case EnumSound.menuSelectionSound:
                audioSource.PlayOneShot(GameAssets.i.menuSelectionSound);
                break;
            case EnumSound.welder:
                audioSource.PlayOneShot(GameAssets.i.welder);
                break;
            case EnumSound.wrench:
                audioSource.PlayOneShot(GameAssets.i.wrench);
                break;
        }
    }*/

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
