using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]Vector2 movingScale = new Vector2(1,1);
    [SerializeField]Vector2 maxPosition = Vector2.zero;
    [SerializeField]float stopSpeed = 3f;
    void LateUpdate()
    {
        var CharacterToViewPort = Camera.main.WorldToViewportPoint(GameCore.Zabi_obj.transform.position);
        var lenghtToMaxPos = Mathf.Max(transform.position.x-maxPosition.x,transform.position.y-maxPosition.y);
        if(lenghtToMaxPos > -0.5f)
        {
            transform.position = Vector3.Lerp(transform.position,new Vector3(maxPosition.x,maxPosition.y,transform.position.z),Time.deltaTime*stopSpeed);
            return;
        }
        if(CharacterToViewPort.x > 0.5f)
        {
            transform.Translate(movingScale*Time.deltaTime);
        }
    }
}
