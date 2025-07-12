using System;
using UnityEngine;

public class WalkingSoundClip : MonoBehaviour
{
    [SerializeField] AudioClip walk_sound;
    void Update()
    {
        if (GetComponent<movementscript>().movement != Vector3.zero)
        {
            AudioSource.PlayClipAtPoint(walk_sound, transform.position + Vector3.down * 1);
        }
    }
}
