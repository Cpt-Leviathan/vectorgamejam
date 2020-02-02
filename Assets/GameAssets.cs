using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i
    {
        get
        {
            if (_i == null)
            {
                _i = Instantiate(Resources.Load<GameAssets>("Prefabs/GameAssets"));
            }
            return _i;
        }
    }

    public AudioClip spaceHit;
    public AudioClip extincteur;
    public AudioClip hammer;
    public AudioClip menuSelectionSound;
    public AudioClip welder;
    public AudioClip wrench;
    public AudioClip ligthYearBackground;
    public AudioClip securityBreachBackground;
    public AudioClip blazingStartBackground;

    public SoundAudioClip[] soundAudioClipArray;

    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManager.EnumSound sound;
        public AudioClip audioClip;
    }
}
