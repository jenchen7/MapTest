using UnityEngine;
using UnityEngine.UI;
using System;

public class DisplayScores : MonoBehaviour
{
    public Text scoreText;
    public static int collectableScore;
    public static int deathCount;
    public static int enemiesDefeated;
    public int mins, secs;
    public string seconds;
 
    void Start () {
        scoreText = GetComponent<Text>();

        // timer stuff
        mins = (int)Math.Floor(Timer.time/60);;
        secs = (int)Timer.time % 60;
        if (secs<10) {
            seconds = "0"+secs.ToString();
        }
        else {
            seconds = secs.ToString();
        }
    }
 
    void Update () {

        scoreText.text = collectableScore.ToString() +"\n\n"+enemiesDefeated.ToString() + "\n\n" + mins.ToString()+":"+seconds;
    }

}
