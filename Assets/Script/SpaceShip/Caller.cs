using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caller : MonoBehaviour
{
    GameObject module;
    float lastCallTime, nextCallTime, callTimer;
    float minTimer, maxTimer;
    float timeUntilEnd, endTime, endTimer;

    public void Init()
    {
        minTimer = 20;
        maxTimer = 60;
        endTime = 12;
        lastCallTime = 0;
        callTimer = 0;
        nextCallTime = Random.Range(minTimer, maxTimer);

        module.SetActive(false);
    }

    public void updateCaller()
    {
        if (!module.activeSelf)
        {
            callTimer += Time.deltaTime;
            if (lastCallTime + callTimer >= nextCallTime)
            {
                module.SetActive(true);
                lastCallTime = Time.time;
                timeUntilEnd = lastCallTime;
            }
        }

        if (module.activeSelf)
        {
            endTimer += Time.deltaTime;
            if (timeUntilEnd + endTimer >= endTime)
            {
                GameFlow gameFlow = (GameFlow)FlowManager.Instance.currentFlow;
                gameFlow.EndGame();
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Player p = collision.gameObject.GetComponent<Player>();

        if (p)
            p.canAnswer = true;
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        Player p = collision.gameObject.GetComponent<Player>();

        if (p)
            p.canAnswer = false;
    }

    public void Hangup()
    {
        module.SetActive(false);
    }
}
