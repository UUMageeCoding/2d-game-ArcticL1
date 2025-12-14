using UnityEngine;

public class audiomanager : MonoBehaviour
{
    [Header("--------Audio Source--------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource totallynotaeastereggSource;

    [Header("--------Audio clip--------")]
    public AudioClip background;
    public AudioClip bossbackground;
    public AudioClip hit;
    public AudioClip death;
    public AudioClip ratdeath;
    public AudioClip roar;
    public AudioClip slash;
    public AudioClip smash;
    public AudioClip flame;
    public AudioClip portal;
    public AudioClip gate;
    public AudioClip easteregg;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        totallynotaeastereggSource.PlayOneShot(clip);
    }
}
