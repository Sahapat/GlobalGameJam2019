using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject PassChecker = null;
    [SerializeField] Transform passDestination = null;
    [SerializeField] float relativeTimeToPass = 0.2f;
    private BoxCollider2D passColiderRef = null;

    private bool passTrigger = false;
    void Awake()
    {
        passColiderRef = PassChecker.GetComponent<BoxCollider2D>();
    }
    void FixedUpdate()
    {
        var checkPosition = new Vector2(PassChecker.transform.position.x+passColiderRef.offset.x,PassChecker.transform.position.y+passColiderRef.offset.y);
        var hitInfo = Physics2D.OverlapBox(checkPosition,passColiderRef.size,0f,LayerMask.GetMask("Zabi"));

        if(hitInfo)
        {
            GamePass();
        }
    }
    public bool isGameStart
    {
        get; private set;
    }
    public bool isGameOver
    {
        get; private set;
    }
    public bool isGamePass
    {
        get; private set;
    }

    public void GameStart()
    {
        isGameStart =true;
    }
    public void GameOver()
    {
        isGameOver = true;
    }
    public void GamePass()
    {
        isGamePass = true;
        if(!passTrigger)
        {
            StartCoroutine(DoPass(GameCore.Zabi_obj,passDestination.position));
            passTrigger = true;
        }
    }
    private IEnumerator DoPass(GameObject targetObject,Vector3 destination)
    {
        while(Vector3.Distance(targetObject.transform.position,destination) != 0)
        {
            targetObject.transform.position = Vector3.MoveTowards(targetObject.transform.position,destination,relativeTimeToPass);
            targetObject.transform.localScale = Vector3.MoveTowards(targetObject.transform.localScale,Vector3.zero,Time.deltaTime);
            yield return null;
        }
    }
}
