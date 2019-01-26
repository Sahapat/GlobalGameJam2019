using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Vector2 movingScale = new Vector2(1, 1);
    [SerializeField] Vector2 maxPosition = Vector2.zero;
    [SerializeField] float focusSpeed = 3f;
    [SerializeField] float stopSpeed = 3f;
    [SerializeField] bool clampMax = false;
    private Vector3 FocusPos;
    private bool isFocus = false;
    void Update()
    {
        if(isFocus)
        {
            transform.position = Vector3.Lerp(transform.position,FocusPos,Time.deltaTime*focusSpeed);
            if(Vector2.Distance(transform.position,FocusPos) < 0.1f)
            {
                isFocus = false;
            }
        }
    }
    void LateUpdate()
    {
        if(isFocus||GameCore.m_gamecontroller.isGameOver||GameCore.m_gamecontroller.isGamePass)return;
        var CharacterToViewPort = Camera.main.WorldToViewportPoint(GameCore.Zabi_obj.transform.position);
        var lenghtToMaxPos = Mathf.Max(transform.position.x - maxPosition.x, transform.position.y - maxPosition.y);
        if (lenghtToMaxPos > -0.5f && clampMax)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(maxPosition.x, maxPosition.y, transform.position.z), Time.deltaTime * stopSpeed);
            return;
        }
        if (CharacterToViewPort.x > 0.5f)
        {
            transform.Translate(movingScale * Time.deltaTime);
        }
    }
    public void SetFocus(Vector3 focusPos)
    {
        isFocus = true;
        FocusPos = focusPos;
    }
}
