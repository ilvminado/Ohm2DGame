using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundCheck : MonoBehaviour
{

    private enemyfollows enemy;

    // Use this for initialization
    void Start()
    {
        enemy = gameObject.GetComponentInParent<enemyfollows>();
    }

    void OnTriggerEnter2D(Collider2D col)

    {
        if (col.CompareTag("Walls"))
        {
            
            enemy.grounded = false;
        }
        else
        {
            enemy.grounded = true;
        }


        if (col.CompareTag("Enemy"))
        {
            enemy.collidingenemy = true;

        }

        else
        {
            enemy.collidingenemy = false;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Walls"))
        {

            enemy.grounded = false;
        }
        else
        {
            enemy.grounded = true;
        }
    }
    // Update is called once per frame

    void OnTriggerExit2D(Collider2D col)
    {
        enemy.grounded = false;
    }
}
