using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{

    private bool enable = true;


    private void OnTriggerExit(Collider other)
    {
        if (enable)
        {
            if (other.CompareTag("Player"))
            {
                enable = false;
                other.GetComponent<Timer>().StartTimer();
            }
        }
        
    }
}
