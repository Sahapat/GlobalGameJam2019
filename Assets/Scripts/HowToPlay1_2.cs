using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay1_2 : MonoBehaviour
{
    [SerializeField] GameObject showingDialog = null;
    private BoxCollider2D m_boxcolider = null;

    void Awake()
    {
        m_boxcolider = GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        showingDialog.SetActive(false);
    }

    void FixedUpdate()
    {
        var checkPosition = new Vector2(transform.position.x + m_boxcolider.offset.x, transform.position.y + m_boxcolider.offset.y);
        var hitInfo = Physics2D.OverlapBox(checkPosition, m_boxcolider.size, 0f, LayerMask.GetMask("Zabi"));

        if (hitInfo)
        {
            showingDialog.SetActive(true);
        }

        if (showingDialog.activeSelf)
        {
#if UNITY_IOS || UNITY_ANDROID
            {
                var touches = Input.touches;
                if (touches.Length > 1)
                {
                    if (touches[1].phase == TouchPhase.Began)
                    {
                        showingDialog.SetActive(false);
                    }
                }
            }
#else
            {
                if (Input.GetMouseButtonDown(1))
                {
                    showingDialog.SetActive(false);
                }
            }
#endif
            {
                if (Input.GetMouseButtonDown(1))
                {
                    showingDialog.SetActive(false);
                }
            }

#if UNITY_EDITOR
            {
                if (Input.GetMouseButtonDown(1))
                {
                    showingDialog.SetActive(false);
                }
            }
#endif
        }
    }
}
