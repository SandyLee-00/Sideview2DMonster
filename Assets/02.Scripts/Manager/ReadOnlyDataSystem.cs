using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReadOnlyDataSystem
{
    private CSVLoader csvLoader;

    public Dictionary<string, LocalMonsterData> MonsterDic { get; private set; }

    public void Init()
    {
        GetOrAddCSVLoader();
        LoadData();
    }

    private void GetOrAddCSVLoader()
    {
        if (csvLoader == null)
        {
            GameObject prefab = ResourceManager.Instance.Load<GameObject>("Prefabs/CSVLoader");
            GameObject loader = UnityEngine.Object.Instantiate(prefab);
            loader.name = "CSVLoader";
            csvLoader = loader.GetOrAddComponent<CSVLoader>();
        }
    }

    private void LoadData()
    {
        MonsterDic = csvLoader.MakeLocalMonsterData();
    }

}