using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        audioSource = GetComponent<AudioSource>();
    }
    public void ToggleMusic()
    {
        audioSource.mute = !audioSource.mute;
    }
}