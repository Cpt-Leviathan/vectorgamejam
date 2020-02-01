﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tiles
{
    bool isDamaged;
    Vector2Int pos;
    TileBase texture;
    List<RequireListTool> repairList;
    Room parent;

    public void init(TileBase tb, Room _parent, Vector2Int v2)
    {
        isDamaged = false;
        texture = tb;
        pos = v2;
        repairList = new List<RequireListTool>();
        parent = _parent;
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
        if (repairList != null)
            if (repairList[0] == tool)
            {
                repairList.RemoveAt(0);
            }
                checkTile();
    }

    public void checkTile()
    {
        if (repairList.Count < 1)
        {
            isDamaged = false;

            parent.tilemap.SetTile((Vector3Int)pos, texture);
            parent.tilemap.RefreshTile((Vector3Int)pos);
            Debug.Log("checking");
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
