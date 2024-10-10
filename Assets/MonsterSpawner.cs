using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public ObjectPool ObjectPool;

    public Vector2 SkeletonSpawnPoint = new Vector2(5, -2.7f);
    public Vector2 EliteOrcSpawnPoint = new Vector2(5, -2.4f);
    public Vector2 WizardSpawnPoint = new Vector2(5, -2.6f);
    public Vector2 WerebearSpawnPoint = new Vector2(5, -2.6f);
    public Vector2 OrcriderSpawnPoint = new Vector2(5, -2.7f);

    // TODO : Define에 옮기기
    public string Skeleton = "MON0001";
    public string EliteOrc = "MON0002";
    public string Wizard = "MON0003";
    public string Werebear = "MON0004";
    public string Orcrider = "MON0005";

    public GameObject currentMonster;

    private void Start()
    {
        ObjectPool = FindAnyObjectByType<ObjectPool>();

        currentMonster = ObjectPool.InstanciateFromPool(Skeleton);
        currentMonster.GetComponent<Monster>().OnMonsterDeath += SpawnNextMonster;
    }

    private void SpawnNextMonster()
    {
        ObjectPool.DestroyToPool(currentMonster);
        LocalMonsterData prevMonsterData = currentMonster.GetComponent<Monster>().monsterData;

        currentMonster = ObjectPool.InstanciateFromPool(prevMonsterData.NextMonsterId);
        Monster monster = currentMonster.GetComponent<Monster>();
        monster.OnMonsterDeath += SpawnNextMonster;
        monster.monsterData = DataManager.Instance.ReadOnlyDataSystem.MonsterDic[prevMonsterData.NextMonsterId];
    }

}
