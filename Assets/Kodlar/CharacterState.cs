using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : MonoBehaviour
{
    public State currentState=State.Idle;
    public Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void ChangeState(State newState)
    {
        currentState = newState;
        animator.CrossFadeInFixedTime(currentState.ToString(),0.2f);
    }
}

public enum State
{
    Idle,
    Walk
}
