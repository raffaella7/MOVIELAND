using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaivor : MonoBehaviour
{
    Animator animator;
    private int currentLane = 1;
    public bool CanSwipe = true;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void Left()
    {
        if (!CanSwipe) return;
        currentLane--;
        animator.SetInteger("CurrentLane", currentLane);
        currentLane = Mathf.Clamp(currentLane, 0, 2);
        // print(currentLane);

    }
    public void Right()
    {
        if (!CanSwipe) return;
        currentLane++;
        animator.SetInteger("CurrentLane", currentLane);
        currentLane = Mathf.Clamp(currentLane, 0, 2);
        // print(currentLane);
    }
    public void OnRestart()
    {
        currentLane = 1;
        animator.SetInteger("CurrentLane", currentLane);

    }

}
