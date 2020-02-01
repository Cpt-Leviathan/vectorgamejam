using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class GameFlow : Flow
{


    override
    public void InitializeFlow()
    {
       
    }

    override
    public void UpdateFlow(float dt)
    {

        Debug.Log("Test");
       
    }


    public void UIEndGame()
    {
      
    }

    override
    public void FixedUpdateFlow(float dt)
    {
       
    }

    override
    public void CloseFlow()
    {
       
    }

    public void SetPause()
    {
       
    }

    public void EndGame()
    {
       
    }

    public void Restart()
    {

        FlowManager.Instance.ChangeFlows(FlowManager.SceneNames.Game);

    }
}
