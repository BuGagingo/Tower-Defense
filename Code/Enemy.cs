using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float borderPosX;
    public Animator animator;

    [Range(1, 100)]
    public float health;
    public int price;
    public int dmg = 1;
    public float shootInterval = 1f;
    public float shootTimer = 0f;

    public float speed = 1;
    public float speedPerLevel = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        borderPosX = Corn.singleton.transform.position.x;
        speed += speedPerLevel * LevelController.level; 
    }

    // Update is called once per frame
    void Update()
    {
        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
        }
        float enemyPosX = transform.position.x;

        if (enemyPosX > borderPosX)
        {
            transform.position += -transform.right * speed * Time.deltaTime;
            animator.SetBool("isMoving", true);
        }
        else
        {
            if(Corn.singleton.health > 0)
            {
                animator.SetBool("isMoving", false);
                if (shootTimer <= 0)
                {
                    Attack();
                    shootTimer = shootInterval;
                }
            }
            else
            {
                transform.position += -transform.right * speed * Time.deltaTime;
                animator.SetBool("isMoving", true);
            }
        }
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
 
        if (health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Corn.singleton.AddCrystals(price);
        Destroy(gameObject);
    }

    public void Attack()
    {
        animator.Play("attack");
        Corn.singleton.TakeDamage(dmg);
    }
}
