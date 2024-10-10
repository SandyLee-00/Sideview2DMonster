using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hitPower = 100;
    public Monster targetMonster;
    public Coroutine takeDamageCoroutine;
    public bool isAttacking = false;

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
            isAttacking = false;
            if (hitColliders[i].CompareTag("Monster"))
            {
                isAttacking = true;

                if (takeDamageCoroutine == null)
                {
                    targetMonster = hitColliders[i].GetComponent<Monster>();
                    takeDamageCoroutine = StartCoroutine(TakeDamageToMonster());
                }
            }
            i++;
        }

        if (isAttacking == false)
        {
            isAttacking = false;
            targetMonster = null;
            if (takeDamageCoroutine != null)
            {
                StopCoroutine(takeDamageCoroutine);
                takeDamageCoroutine = null;
            }
        }
    }

    private IEnumerator TakeDamageToMonster()
    {
        while(true)
        {
            Debug.Log("TakeDamageToMonster");
            if (targetMonster != null)
            {
                targetMonster.TakeDamage(hitPower);
                yield return new WaitForSeconds(1f);
            }
            else
            {
                yield break;
            }
        }
    }
}
