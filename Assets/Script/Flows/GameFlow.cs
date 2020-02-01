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
        PlayerManager.Instance.init();
        ToolsManager.Instance.init();
        SpaceShipManager.Instance.init();
        UIManager.Instance.init();
    }

    override
    public void UpdateFlow(float dt)
    {

        PlayerManager.Instance.Update();
        ToolsManager.Instance.Update();
        SpaceShipManager.Instance.Update();
        UIManager.Instance.Update();

    }

    override
    public void FixedUpdateFlow(float dt)
    {
        PlayerManager.Instance.FixedUpdate();
        ToolsManager.Instance.FixedUpdate();
        SpaceShipManager.Instance.FixedUpdate();
        UIManager.Instance.FixedUpdate();
    }

    override
    public void CloseFlow()
    {
       
    }

    public void SetPause()
    {
       
    }

    public void Restart()
    {

        FlowManager.Instance.ChangeFlows(FlowManager.SceneNames.Game);

    }
}
