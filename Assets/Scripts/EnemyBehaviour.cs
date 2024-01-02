using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private int maxHealth = 3;
    private int currHealth;
    private Rigidbody rb;
    Vector3 moveDirection;

    void Start() {
        currHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 60*Time.deltaTime, 0);
    }

    // take damage, play sound, and knock back upon collision with player
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player") {
            MovePlayer.sounds[1].Play();
            currHealth--;
            moveDirection = rb.transform.position - other.transform.position;
            rb.AddForce(moveDirection.normalized * 40f, ForceMode.Impulse);
            //Debug.Log(currHealth.ToString());

            // kills enemy if health reaches 0
            if (currHealth <= 0) {
                KillEnemy();
            }
        }
    }

    // destorys enemy and adds to score
    void KillEnemy() {
        MovePlayer.sounds[2].Play();
        Destroy(gameObject);
        DisplayScores.enemiesDefeated++;
    }
    
}