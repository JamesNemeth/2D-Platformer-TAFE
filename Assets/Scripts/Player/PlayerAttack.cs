using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    private float timeBtwBlaze;
    public float startTimeBtwBlaze;

    private float timeBtwPacify;
    public float startTimeBtwPacify;

    private float timeBtwFlash;
    public float startTimeBtwFlash;

    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public int damageJab;
    public int damageBlaze;
    public int damagePacify;
    public int flashHeals;
    public Animator animator;

    void Update()
    {
        if (timeBtwAttack <= 1)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damageJab);
                }
                timeBtwAttack = startTimeBtwAttack;
                animator.SetBool("isJabbing", true);

            }
            else
            {
                animator.SetBool("isJabbing", false);
            }
        }
        else
        {
            startTimeBtwAttack -= Time.deltaTime;
        }

        if (timeBtwBlaze <= 2)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damageBlaze);
                }
                timeBtwBlaze = startTimeBtwBlaze;
                animator.SetBool("castBlaze", true);

            }
            else
            {
                animator.SetBool("castBlaze", false);
            }
        }
        else
        {
            startTimeBtwAttack -= Time.deltaTime;
        }


        if (timeBtwPacify <= 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damagePacify);
                }
                timeBtwPacify = startTimeBtwPacify;
                animator.SetBool("castPacify", true);
            }
            else
            {
                animator.SetBool("castPacify", false);
            }
        }
        else
        {
            timeBtwPacify -= Time.deltaTime;
            //animator.SetBool("castPacify", false);
        }

        if (timeBtwFlash <= 0)
        {
           if (Input.GetKeyDown(KeyCode.Q))
            {
                animator.SetBool("castFlash", true);
                timeBtwFlash = startTimeBtwFlash;
            }
           else
            {
                animator.SetBool("castFlash", false);
            }
        }
        else
        {
            timeBtwFlash -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}