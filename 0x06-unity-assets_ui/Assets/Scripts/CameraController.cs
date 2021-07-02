using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed;
    public Transform target, player;
    float mouseX, mouseY;
    public bool activeCamera = true;
    public static bool isInverted = false;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (activeCamera)
        {
            mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
            mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
            mouseY = Mathf.Clamp(mouseY, -35, 60);

            transform.LookAt(target);

            if (isInverted)
            {
                target.transform.rotation = Quaternion.Euler(-mouseY, mouseX, 0);
            } else
            {
                target.transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            }

            
            player.transform.rotation = Quaternion.Euler(0, mouseX, 0);
        }
        
    }

    public void Pause()
    {
        activeCamera = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    

    public void Resume()
    {
        activeCamera = true;
        Cursor.visible = false;
    }
}
