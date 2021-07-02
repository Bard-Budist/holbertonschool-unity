using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public Toggle isInvertesToggle;
    private bool localInverted;

    private void Start()
    {
        localInverted = CameraController.isInvertedGlobal;
        isInvertesToggle.isOn = localInverted;

    }
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Apply()
    {
        CameraController.isInvertedGlobal = !localInverted;
        SceneManager.LoadScene(PauseMenu.lastScene);
    }
}
