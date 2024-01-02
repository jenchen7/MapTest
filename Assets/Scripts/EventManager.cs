using UnityEngine;
using System.Collections;
using UnityEngine.Events;


public class EventManager : MonoBehaviour 
{

    private float currentState;
    public UnityEvent<float> stateChangeEvent;

    public void ChangeState(float newState)
    {
        currentState = newState;

        //Here we invoke the event, with our new state as the parameter.
        //It will trigger any listeners that happen to be listening.
        stateChangeEvent.Invoke(newState);
    }
}