using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }
    }
}
