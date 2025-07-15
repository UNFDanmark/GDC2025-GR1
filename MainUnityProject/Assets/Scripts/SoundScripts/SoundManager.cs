using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public SoundData[] sounds;
    [Range(0,1)]
    public float level;

    AudioSource audioSource;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = level;
    }

    public void playSound(string soundname)
    {
        for (int i = 0; i < sounds.Length; i +=1)
        {
            if (sounds[i].soundName == soundname)
            {
                audioSource.PlayOneShot(sounds[i].sound);
            }
        }
    }
}
