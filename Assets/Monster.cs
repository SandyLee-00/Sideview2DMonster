using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public bool isMoving = true;

    public int currentHp;
    public Action OnMonsterDeath;

    public LocalMonsterData monsterData;

    public Image HPBarImage;

    public void Init(string monsterId)
    {
        monsterData = DataManager.Instance.ReadOnlyDataSystem.MonsterDic[monsterId];
        currentHp = monsterData.Health;
        isMoving = true;
    }

    private void Update()
    {
        if (isMoving)
        {
            Move();
        }
    }

    private void Move()
    {
        transform.Translate(Vector3.left * monsterData.Speed * 5 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isMoving = false;
        }
    }

    public bool TakeDamage(int hitPower)
    {
        currentHp -= hitPower;
        Debug.Log("Monster HP : " + currentHp);

        HPBarImage.fillAmount = (float)currentHp / monsterData.Health;

        if (currentHp <= 0)
        {
            Die();
            return true;
        }
        return false;
    }

    private void Die()
    {
        OnMonsterDeath?.Invoke();
    }
}
