using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public Vector2 SkeletonSpawnPoint = new Vector2(5, -2.7f);
    public Vector2 EliteOrcSpawnPoint = new Vector2(5, -2.4f);
    public Vector2 WizardSpawnPoint = new Vector2(5, -2.7f);
    public Vector2 WerebearSpawnPoint = new Vector2(5, -2.7f);

    public string Skeleton = "MON0001";
    public string EliteOrc = "MON0002";
    public string Wizard = "MON0003";
    public string Werebear = "MON0004";
    public string Orcrider = "MON0005";

    private void Start()
    {
        string id = DataManager.Instance.ReadOnlyDataSystem.MonsterDic[Skeleton].Id;
        Debug.Log(id);
    }

}
