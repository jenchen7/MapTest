using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndzoneBehaviour : MonoBehaviour
{
    // loads completion screen
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            Timer.strt = false;
            SceneManager.LoadScene("Scores");
        }
    }

}
