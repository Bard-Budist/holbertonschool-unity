using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LevelSelect(int level)
    {
        if (level >=1 && level <= 3)
        {
            PauseMenu.lastScene = "Level0" + level.ToString();
            SceneManager.LoadScene(level);
        }
        
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void ExitGame()
    {
        Debug.Log("Exited");
        Application.Quit();
    }

}
