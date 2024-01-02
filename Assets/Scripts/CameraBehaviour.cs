using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;

    float distance = 20.0f;
    float height = 15.0f;
    float smooth = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerModel").transform;
        offset = new Vector3(0f, height, -distance);
    }

    void LateUpdate()
    {
        Vector3 thisPosition = player.position + offset;
        transform.position = Vector3.Slerp(transform.position, thisPosition, smooth);

        transform.LookAt(player);
    }
}