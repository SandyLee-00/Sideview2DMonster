using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float moveSpeed = 2f;
    private bool isMoving = true;

    public int maxHp = 200;
    public int currentHp;

    private void Start()
    {
        currentHp = maxHp;
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
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
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
        Destroy(gameObject);
    }
}
