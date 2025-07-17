using TMPro;
using UnityEngine;
[System.Serializable]
public class DialogueData
{
    public string Speaker;

    public string soundName;

    public string text;
    public TMP_FontAsset font;
    
    public string PlayEvent = "";

    public Sprite SpeakerImage;
}