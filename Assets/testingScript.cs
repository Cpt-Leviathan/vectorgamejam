using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testingScript : MonoBehaviour
{
    List<int> testlist;
    // Start is called before the first frame update
    void Start()
    {
        testlist = new List<int>();
        //SoundManager.Instance.PlaySound(EnumSound.Background);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RepairList.generateListOrders(7);
            SoundManager.Instance.PlaySound(EnumSound.spaceHit);
            //SoundManager.PlaySound();
        }
    }
}
