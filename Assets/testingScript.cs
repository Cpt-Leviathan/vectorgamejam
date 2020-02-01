using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testingScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        RepairList.init();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RepairList.generateListOrder(3);
        }
    }
}
