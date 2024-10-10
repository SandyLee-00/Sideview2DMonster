using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public ReadOnlyDataSystem ReadOnlyDataSystem { get; private set; }
    /*public ServerDataSystem ServerDataSystem { get; private set; }
    public LocalDataSystem LocalDataSystem { get; private set; }*/

    protected override void Awake()
    {
        _isDontDestroyOnLoad = true;
        base.Awake();

        ReadOnlyDataSystem = new ReadOnlyDataSystem();
        /*ServerDataSystem = new ServerDataSystem();
        LocalDataSystem = new LocalDataSystem();*/

        ReadOnlyDataSystem.Init();
        /*ServerDataSystem.Init();
        LocalDataSystem.Init();*/
    }
}

