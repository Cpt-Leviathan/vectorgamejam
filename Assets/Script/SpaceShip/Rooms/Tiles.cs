using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tiles
{
    bool isDamaged;
    TileBase tile;
    List<RequireListTool> repairList;

    public void init(TileBase tileMapTile)
    {
        isDamaged = false;
        tile = tileMapTile;
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

    public bool getIsDamaged()
    {
        return isDamaged;
    }
}
