using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaivor : MonoBehaviour
{
    Animator animator;
    private int currentLane = 1; 
    void Awake(){
        animator=GetComponent<Animator>();
    }
    public void Left()
    {
        currentLane--;
        animator.SetInteger("CurrentLane",currentLane);
        currentLane = Mathf.Clamp(currentLane,0,2);
        print(currentLane);
    }
    public void Right()
    {
        currentLane++;
        animator.SetInteger("CurrentLane",currentLane);
        currentLane = Mathf.Clamp(currentLane,0,2);
        print(currentLane);
    }
    
}
