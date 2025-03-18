using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public MusicType musicType;
    public SoundManager soundManager;
    public AudioSource audioSource;

    private MusicSetup _currentMusicSetup;

    void Awake()
    {
        soundManager = FindFirstObjectByType<SoundManager>();
    }

    void Start()
    {
        Play();
    }

    private void Play()
    {
        _currentMusicSetup = soundManager.GetMusicByType(musicType);

        audioSource.clip = _currentMusicSetup._clip;
        audioSource.Play();
    }
}
