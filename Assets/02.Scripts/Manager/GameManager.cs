using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public UIPopup_MonsterInfo UIPopup_MonsterInfo;

    protected override void Awake()
    {
        _isDontDestroyOnLoad = true;
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();

        
    }
}
