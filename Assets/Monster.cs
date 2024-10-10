using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private bool isMoving = true;

    public int currentHp;
    public Action OnMonsterDeath;

    public LocalMonsterData monsterData;


    private void Start()
    {
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
        transform.Translate(Vector3.left * monsterData.Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isMoving = false;
        }
    }

    public void TakeDamage(int hitPower)
    {
        currentHp -= hitPower;
        Debug.Log("Monster HP : " + currentHp);
        if (currentHp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        OnMonsterDeath?.Invoke();
    }
}
