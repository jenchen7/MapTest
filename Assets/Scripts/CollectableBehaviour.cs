using UnityEngine;

public class CollectableBehaviour : MonoBehaviour
{

    void Start() {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(30*Time.deltaTime, 15*Time.deltaTime, 45*Time.deltaTime);
    }

    // play sound effect and destory upon collision with player
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            MovePlayer.sounds[0].Play();
            Destroy (gameObject);
            DisplayScores.collectableScore++;
        }
    }
    
}