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

        StartCoroutine(WaitforLoadUserData());
    }

    // TODO : 로딩 될 때 기다리고 데이터 설정 로드매니저 필요?
    private IEnumerator WaitforLoadUserData()
    {
        yield return new WaitUntil(() => DataManager.Instance.ServerDataSystem.User != null);
        UIScene_MainScene.SetKillMonsterText(DataManager.Instance.ServerDataSystem.User.KillCount);
    }

    // TODO : 이벤트로 수정? 
    private void OnPlayerKillMonster()
    {
        DataManager.Instance.ServerDataSystem.User.KillCount++;
        UIScene_MainScene.SetKillMonsterText(DataManager.Instance.ServerDataSystem.User.KillCount);
        DataManager.Instance.ServerDataSystem.SaveUserData();
    }
}
