using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private Timer timer;
    private CameraController cameraController;
    private PlayerController playerController;
    public static string lastScene;

    public GameObject canvasPause;

    private void Start()
    {
        timer = FindObjectOfType<Timer>();
        playerController = GetComponent<PlayerController>();
        cameraController = FindObjectOfType<CameraController>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    public void Pause()
    {
        timer.PauseTimer();
        canvasPause.SetActive(true);
        cameraController.Pause();
        playerController.canMove = false;
    }

    public void Resume()
    {
        timer.StartTimer();
        canvasPause.SetActive(false);
        cameraController.Resume();
        playerController.canMove = true;
    }

    public void Restart()
    {
        string nameScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(nameScene);
    }

    public void MainMenu()
    {
        lastScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("MainMenu");
    }

    public void Options()
    {
        lastScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Options");
    }
}
