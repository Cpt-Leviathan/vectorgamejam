﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool
{

    private int durability, durabilityCost, durabilityMax;
    private RequireListTool type;
    private double repairSpeed;

    virtual public void InitTool(RequireListTool type_, int durabilityMax_, int durabilityCost_)
    {
        type = type_;
        durabilityMax = durabilityMax_;
        durability = durabilityMax;
        durabilityCost = durabilityCost_;
    }

    virtual public void UpdateTool()
    {

    }

    //
    //From player, Give Use a tile to repair
    //
    virtual public void Use()
    {
        if (durability > 0)
        {
            durability -= durabilityCost;
            Debug.Log("use" + type );
        }
    }

    public void FillEnergy()
    {
        Debug.Log("Refilling.....");
        durability = durabilityMax;
    }
}
