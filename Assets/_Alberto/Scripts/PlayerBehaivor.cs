using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaivor : MonoBehaviour
{
    Animator animator;
    [SerializeField] public int currentLane = 1;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void Left()
    {
        currentLane--;
        currentLane = Mathf.Clamp(currentLane, 0, 2);
        animator.SetInteger("CurrentLane", currentLane);
        print(currentLane);
    }
    public void Right()
    {
        currentLane++;
        currentLane = Mathf.Clamp(currentLane, 0, 2);
        animator.SetInteger("CurrentLane", currentLane);
        print(currentLane);
    }
    public void OnRestart()
    {
        currentLane = 1;
        animator.SetInteger("CurrentLane", currentLane);

    }

}
