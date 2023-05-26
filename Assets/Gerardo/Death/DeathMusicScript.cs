using UnityEngine;

public class DeathMusicScript : MonoBehaviour
{
    public AudioClip deathMusic;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayDeathMusic()
    {
        audioSource.clip = deathMusic;
        audioSource.Play();
    }
}
