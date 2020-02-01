using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tiles
{
    bool isDamaged;
    Vector2Int pos;
    TileBase texture;
    List<RequireListTool> repairList;

    public void init(TileBase tb)
    {
        isDamaged = false;
        texture = tb;
        repairList = new List<RequireListTool>();
    }
    
    public void damageTile()
    {
        List<RequireListTool> tempList = RepairList.generateListOrders((int)Random.Range(0, 6));
        foreach (RequireListTool rlt in tempList)
        {
            repairList.Add(rlt);
        }
        isDamaged = true;
    }

    public void repairTile(RequireListTool tool)
    {
        if (repairList[0] == tool)
        {
            repairList.RemoveAt(0);
            checkTile();
        }
    }

    public void checkTile()
    {
        if (repairList.Count > 1)
        {
            isDamaged = false;
        }
    }

    public void setPos(Vector2Int v)
    {
        pos = v;
    }

    public bool getIsDamaged()
    {
        return isDamaged;
    }
}
