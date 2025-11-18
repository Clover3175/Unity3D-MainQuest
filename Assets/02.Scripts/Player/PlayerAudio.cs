using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private float audioSound = 1.0f;
    [SerializeField] private AudioClip[] audioClip;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void SoundNumber(int soundIndex)
    {
        if (soundIndex >= 0 && soundIndex < audioClip.Length)
        {
            audioSource.PlayOneShot(audioClip[soundIndex], audioSound);
        }
    }
}
