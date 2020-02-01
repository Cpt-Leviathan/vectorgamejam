using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool
{
    protected int energy, energyCost, energyMax;
    protected double repairSpeed;

    virtual public void InitTool()
    {
        energy = 100;
        energyCost = 10;
        energyMax = 100;
    }

    virtual public void UpdateTool()
    {

    }

    //
    //From player, Give Use a tile to repair
    //
    virtual public void Use()
    {
        if (energy > 0)
        {
            energy -= energyCost;
        }
    }

    public void FillEnergy()
    {
        energy = energyMax;
    }
}
