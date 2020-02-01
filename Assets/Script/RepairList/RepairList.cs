using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RequireListTool
{
    Hammer,
    Extincteur,
    Welder,
    Wrench,
}
public static class RepairList
{

    public static int enumLength = Enum.GetNames(typeof(RequireListTool)).Length;
    public static List<int> toolList;

    public static void init()
    {
        toolList = new List<int>();
    }
    public static void generateListOrder(int numberToolNeeded)
    {
        int randomTool = 0;
        for (int i = 0; i < numberToolNeeded; i++)
        {
            randomTool = UnityEngine.Random.Range(0, enumLength);
            toolList.Add(randomTool);
        }


        foreach (int toolID in toolList)
        {
            Debug.Log("Tool ID in list : " + toolID);
        }
        //Debug.Log("Random number :" + randomTool);
        //Debug.Log(enumLength);
    }

}
