using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGame
{
    UILink ui;
    Image toolBox1;
    Image toolBox2;
    Image toolBox3;
    Image toolBox4;

    public bool isSelected = false;
    List<Image> toolList;
    public void Init()
    {
        toolList = new List<Image>();
        ui = GameObject.FindGameObjectsWithTag("UILink")[0].GetComponent<UILink>();
        toolBox1 = ui.tool1;
        toolBox2 = ui.tool2;
        toolBox3 = ui.tool3;
        toolBox4 = ui.tool4;
        toolList.Add(toolBox1);
        toolList.Add(toolBox2);
        toolList.Add(toolBox3);
        toolList.Add(toolBox4);
    }

    public void SetHighLigthActive(RequireListTool toolID)
    {
        Debug.Log(toolList.Count);
        for (int i = 0; i < toolList.Count; i++)
        {
            toolList[i].color = Color.black;
        }
        toolList[(int)toolID].color = Color.green;
        Debug.Log("number: " + (int)toolID);
        /*switch (toolID)
        {
            case RequireListTool.Extincteur:
                if (isSelected)
                {
                    toolBox1.color = Color.green;
                    isSelected = true;
                }
                break;
            case RequireListTool.Hammer:
                if (isSelected)
                {
                    toolBox2.color = Color.green;
                    isSelected = true;
                }
                break;
            case RequireListTool.Welder:
                if (isSelected)
                {
                    toolBox3.color = Color.green;
                    isSelected = true;
                }
                break;
            case RequireListTool.Wrench:
                if (isSelected)
                {
                    toolBox4.color = Color.green;
                    isSelected = true;
                }
                break;
            default:
                if (!isSelected)
                {
                    toolBox1.color = Color.black;
                    toolBox2.color = Color.black;
                    toolBox3.color = Color.black;
                    toolBox4.color = Color.black;
                }

                break;
        }*/
    }

}
