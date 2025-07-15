using UnityEngine;

public class PlaySoundTemplate : MonoBehaviour
{
    string soundName = "Sound Name";

    public SoundManager soundManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        soundManager.playSound(soundName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
