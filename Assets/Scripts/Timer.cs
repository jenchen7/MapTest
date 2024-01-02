using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Timer : MonoBehaviour
{
    public static float time;
    public static bool strt, stp;
    public Text timerText;
    public int mins, secs;
    public string seconds;

    // Start is called before the first frame update
    void Start()
    {
        GameObject timerui = GameObject.Find("DisplayTimer");
        timerText = timerui.GetComponent<Text>();

        time = 0;
        strt = true;
        stp = false;
    }

    void Update()
    {
        time += Time.deltaTime;

        // display on-screen
        timerText.text = FormatTime();

    }

    string FormatTime() {
        // timer stuff
        mins = (int)Math.Floor(time/60);
        secs = (int)time % 60;

        if (secs<10) {
            return mins.ToString()+":0"+secs.ToString();
        }
        else {
            return mins.ToString()+":"+secs.ToString(); 
        }
    }

}
