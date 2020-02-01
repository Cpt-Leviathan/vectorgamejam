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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RepairList.generateListOrders(7);
        }
    }
}
