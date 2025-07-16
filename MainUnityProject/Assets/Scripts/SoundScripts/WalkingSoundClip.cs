using System;
using System.Collections;
using UnityEngine;

public class WalkingSoundClip : MonoBehaviour
{
    [SerializeField] AudioClip walk_sound;
    [SerializeField] float Delay = .3f;

    void Start()
    {
        StartCoroutine(walksound());
    }

    IEnumerator walksound()
    {
        while (true)
        {
            if (GetComponent<movementscript>().movement != Vector3.zero)
            {
                AudioSource.PlayClipAtPoint(walk_sound, transform.position + Vector3.down * 1);
            }

            yield return new WaitForSeconds(Delay);
        }
        
    }
}
