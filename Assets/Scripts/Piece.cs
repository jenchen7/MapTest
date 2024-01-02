using UnityEngine;

public class Piece : MonoBehaviour
{
    public int index;

    public delegate void ReachTransitionEvent(Piece piece);

    public ReachTransitionEvent OnReachEnd;
    public ReachTransitionEvent OnReachStart;

    public void OnDisable()
    {
        OnReachStart = null;
        OnReachEnd = null;
    }
}
