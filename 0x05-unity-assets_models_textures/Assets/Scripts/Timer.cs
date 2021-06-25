using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    private float segunds;
    private float minutes;

    private bool startTimer = false;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            segunds += Time.deltaTime;
            minutes = (int)segunds / 60;

            TimerText.text = minutes + ":" + (segunds % 60 > 10 ? "" : "0") + (segunds % 60).ToString("f2");
        }
        
    }

    public void StartTimer()
    {
        startTimer = true;
    }

    public void WinText()
    {
        TimerText.fontSize = 60;
        TimerText.color = Color.green;
        startTimer = false;
    }
}
