using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public Canvas winCanvas;

    private CameraController cameraController;
    private PlayerController playerController;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        cameraController = FindObjectOfType<CameraController>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            winCanvas.gameObject.SetActive(true);
            other.GetComponent<Timer>().Win();
            cameraController.Pause();
            playerController.canMove = false;
        }
    }

}
