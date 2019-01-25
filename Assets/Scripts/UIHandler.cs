using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIHandler : MonoBehaviour
{
    [SerializeField] Text touch1Status = null;
    [SerializeField] Text touch2Status = null;


    public void UpdateTouch1Status(string txt)
    {
        touch1Status.text = txt;
    }
    public void UpdateTouch2Status(string txt)
    {
        touch2Status.text = txt;
    }
}
