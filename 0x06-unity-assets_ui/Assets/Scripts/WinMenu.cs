using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Next()
    {
        char number = PauseMenu.lastScene[PauseMenu.lastScene.Length - 1];
        if (number == '3')
        {
            number = '1';
        } else
        {
            number++;
        }
        Debug.Log(number);
        
        string level = "Level0" + number.ToString();
        PauseMenu.lastScene = level;
        SceneManager.LoadScene(level);
    }
}
