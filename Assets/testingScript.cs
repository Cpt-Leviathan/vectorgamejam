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
            SoundManager.PlaySound(SoundManager.EnumSound.spaceHit);
            //SoundManager.PlaySound();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SoundManager.PlaySound(SoundManager.EnumSound.extincteur);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            SoundManager.PlaySound(SoundManager.EnumSound.hammer);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SoundManager.PlaySound(SoundManager.EnumSound.menuSelectionSound);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SoundManager.PlaySound(SoundManager.EnumSound.welder);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            SoundManager.PlaySound(SoundManager.EnumSound.wrench);
        }
    }
}
