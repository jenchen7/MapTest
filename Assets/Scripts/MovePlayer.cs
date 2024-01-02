using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour {

    NavMeshAgent agent;
    Vector2 mousePosition;
    public static AudioSource[] sounds;
    
    void Start() {
        agent = GetComponent<NavMeshAgent>();
        sounds = GetComponents<AudioSource>();
    }
    
    void Update() {

    }

    void OnClickToMove() {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray,out hit, 100)) {
            agent.destination = hit.point;
        }

    }

}