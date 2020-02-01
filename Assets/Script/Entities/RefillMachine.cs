using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillMachine : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Player>().canRefill = true;
        //Debug.Log("REFILL YA CUNT");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Player>().canRefill = false;
        //Debug.Log("FAKIN IDIOT YOU CANT ANYMORE");
    }
}
