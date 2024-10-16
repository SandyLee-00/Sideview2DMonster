using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    /*public ObjectPool ObjectPool;*/
    public Player player;

    // TODO : Define에 옮기기
    public string Skeleton = "MON0001";
    public string EliteOrc = "MON0002";
    public string Wizard = "MON0003";
    public string Werebear = "MON0004";
    public string Orcrider = "MON0005";

    public GameObject currentMonster;

    public Dictionary<string, Vector3> monsterSpawnPoint = new Dictionary<string, Vector3>();

    private void Start()
    {
        monsterSpawnPoint.Add(Skeleton, new Vector3(1, -2.7f, -1));
        monsterSpawnPoint.Add(EliteOrc, new Vector3(5, -2.4f, -1));
        monsterSpawnPoint.Add(Wizard, new Vector3(5, -2.6f, -1));
        monsterSpawnPoint.Add(Werebear, new Vector3(5, -2.6f, -1));
        monsterSpawnPoint.Add(Orcrider, new Vector3(5, -2.7f, -1));

        /*ObjectPool = FindAnyObjectByType<ObjectPool>();*/
        player = FindAnyObjectByType<Player>();
        player.OnKillMonster -= SpawnNextMonster;
        player.OnKillMonster += SpawnNextMonster;

        InitMonster(Skeleton);
    }

    /// <summary>
    /// 풀에서 갖고오기
    /// setActive, 위치, 죽었을 때 이벤트, 몬스터 데이터, 체력 설정
    /// TODO : 풀 쓰면 몬스터 다시 꺼낼 때 유니티 자체가 멈춘다 일단 그냥 생성 삭제하기
    /// </summary>
    /// <param name="MonsterId"></param>
    private void InitMonster(string MonsterId)
    {
        /*currentMonster = ObjectPool.InstanciateFromPool(MonsterId);*/

        currentMonster = ResourceManager.Instance.Instantiate("Monster/" + MonsterId);
        currentMonster.transform.position = monsterSpawnPoint[MonsterId];

        // TODO : 몬스터 코드에서 하는게 맞는 것은 옮기기
        Monster monster = currentMonster.GetComponent<Monster>();
        monster.Init(MonsterId);
    }

    private void SpawnNextMonster()
    {
        LocalMonsterData deadMonsterData = currentMonster.GetComponent<Monster>().monsterData;
        Destroy(currentMonster);

        /*ObjectPool.DestroyToPool(currentMonster);*/
        InitMonster(deadMonsterData.NextMonsterId);
    }

}
