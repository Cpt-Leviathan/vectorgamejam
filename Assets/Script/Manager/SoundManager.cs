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

    GameAssets ga;
    /*public void PlaySound()
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
       
        audioSource.PlayOneShot(ga.extincteur);
    }*/

    public void PlaySound(EnumSound sound)
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
    }
}
