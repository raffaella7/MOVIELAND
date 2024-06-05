using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaivor : MonoBehaviour
{
    private GameObject player;
    public int currentLane; 
    void Awake()
    {
       player= FindAnyObjectByType<GameObject>(); 
    }

    public void Left()
    {
        currentLane--;
        currentLane = Mathf.Clamp(currentLane,0,2);
    }
    public void Right()
    {
        currentLane++;
        currentLane = Mathf.Clamp(currentLane,0,2);
    }
    
}
