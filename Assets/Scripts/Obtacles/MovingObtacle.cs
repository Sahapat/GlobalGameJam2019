using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObtacle : SwitchingObtacle
{
    [SerializeField] Vector2 firstPosition = Vector2.zero;
    [SerializeField] Vector2 secondPosition = Vector2.zero;

    private Vector2 destination = Vector2.zero;

    
    public override void SwitchObtacle()
    {
        
    }
}
