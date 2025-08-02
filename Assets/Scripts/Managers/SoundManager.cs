using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioSource soundFXObject;
    public bool destroy = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public AudioSource PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume, bool loop = false)
    {
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.loop = loop;
        audioSource.Play();
        if (!loop)
        {
            float clipLength = audioSource.clip.length;
            Destroy(audioSource.gameObject, clipLength);
        }
        return audioSource;
    }
}
