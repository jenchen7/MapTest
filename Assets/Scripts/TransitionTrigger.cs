using UnityEngine;
using UnityEngine.AI;

public class TransitionTrigger : MonoBehaviour
{
    public bool isEnd;
    public bool isTop;
    public bool isBottom;

    [SerializeField] Piece parent;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<NavMeshAgent>() != null)
        {
            if (isEnd)
            {
                parent?.OnReachEnd?.Invoke(parent);
            }
            else
            {
                parent?.OnReachStart?.Invoke(parent);

            }
        }
    }
}
