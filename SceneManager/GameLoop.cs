using CatFM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// 游戏主循环
/// </summary>
public class GameLoop : MonoBehaviour
{
    private SceneStateController sceneStateController = new SceneStateController();

    private void Awake()
    {
        DontDestroyOnLoad(this);
        MonoController.AddUpdateListener(GameUpdate);
        MsgCenter.AddListener(MsgDefine.CGPlayFinished, OnCGPlayFinished);
    }

    private void Start()
    {
        this.sceneStateController.SetState(new IndexState(this.sceneStateController), "");
    }

    private void GameUpdate()
    {
        this.sceneStateController.StateUpdate();
    }

    private void OnCGPlayFinished()
    {
        this.sceneStateController.SetState(new HotFixState(this.sceneStateController), "HotFix");
    }
}
