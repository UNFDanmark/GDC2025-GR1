using System.Collections;
using UnityEngine;

public class kys : MonoBehaviour
{

    public float delay = 10;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(kms());
    }

    IEnumerator kms()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
