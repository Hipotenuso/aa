using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public List<MusicSetup> musicSetups;
    public List<SFXSetup> sfxSetups;

    public AudioSource musicSource;

    public void PlayMusicByType(MusicType musicType)
    {
        var music = GetMusicByType(musicType);
        musicSource.clip = music._clip;
        musicSource.Play();
    }

    public MusicSetup GetMusicByType(MusicType musicType)
    {
        return musicSetups.Find(i => i.musicType == musicType);
    }

    public SFXSetup GetSFXByType(SFXType sfxType)
    {
        return sfxSetups.Find(i => i.sfxType == sfxType);
    }
}

public enum MusicType
{
    Type_01,
    Type_02,
    Type_03
}

[System.Serializable]
public class MusicSetup
{
    public MusicType musicType;
    public AudioClip _clip;
}

public enum SFXType
{
    Type_01,
    Type_02,
    Type_03,
    NONE,
}

[System.Serializable]
public class SFXSetup
{
    public SFXType sfxType;
    public AudioClip _clip;
}
