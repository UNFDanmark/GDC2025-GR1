using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSwitcher : MonoBehaviour
{

    public MyEnum DropdownMenu = new MyEnum();
    
    public enum MyEnum
    {
        Settings,
        Bank
    };
        
    public void switchTo()
    {
        SceneManager.LoadScene(DropdownMenu.ToString());
        print(DropdownMenu);
    }
}
