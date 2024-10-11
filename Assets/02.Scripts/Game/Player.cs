using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hitPower = 100;
    public Monster targetMonster;
    public Coroutine takeDamageCoroutine;
    public bool isAttacking = false;
    public Action OnKillMonster;

    private void FixedUpdate()
    {
        FindMonsterCollider();
    }

    // TODO : Fixed에서 계속 호출 줄이기 
    private void FindMonsterCollider()
    {
        Collider[] hitColliders = Physics.OverlapBox(transform.position, transform.localScale / 2, Quaternion.identity);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].CompareTag("Monster"))
            {
                if (isAttacking == false)
                {
                    isAttacking = true;
                    targetMonster = hitColliders[i].GetComponent<Monster>();
                    takeDamageCoroutine = StartCoroutine(TakeDamageToMonster());
                    targetMonster.OnMonsterDeath -= KillMonster;
                    targetMonster.OnMonsterDeath += KillMonster;
                }
            }
            i++;
        }

        // TODO : 굳이 매 프레임마다?
        if (isAttacking == false)
        {
            targetMonster = null;
            if (takeDamageCoroutine != null)
            {
                StopCoroutine(takeDamageCoroutine);
                takeDamageCoroutine = null;
            }
        }
    }

    private void KillMonster()
    {
        isAttacking = false;
        OnKillMonster?.Invoke();
    }

    private IEnumerator TakeDamageToMonster()
    {
        while(true)
        {
            if (targetMonster != null)
            {
                targetMonster.TakeDamage(hitPower);
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
