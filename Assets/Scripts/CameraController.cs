using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]Transform targetPlayer = null;
    [SerializeField]Vector2 movingScale = new Vector2(1,1);
    
    void LateUpdate()
    {
        var CharacterToViewPort = Camera.main.WorldToViewportPoint(targetPlayer.position);
        if(CharacterToViewPort.x > 0.5f)
        {
            transform.Translate(movingScale*Time.deltaTime);
        }
    }
}
