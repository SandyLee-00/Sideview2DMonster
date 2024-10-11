using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public UIPopup_MonsterInfo UIPopup_MonsterInfo;

    public UIScene_MainScene UIScene_MainScene;
    public int KillMonsterCount = 0;

    public Player Player;

    protected override void Awake()
    {
        _isDontDestroyOnLoad = true;
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();

        if(Player == null)
        {
            Player = FindObjectOfType<Player>();
        }
        Player.OnKillMonster += OnPlayerKillMonster;
    }

    private void OnPlayerKillMonster()
    {
        KillMonsterCount++;
        UIScene_MainScene.SetKillMonsterText(KillMonsterCount);
    }
}
