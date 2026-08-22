using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocatorLaser : MonoBehaviour
{

    //private Player player;
    //private Player player;
    public bool cyclop = true;
    public BossStandarCode boss;
    public CyclopRain enemy;
    public bool onlocation;
    //	private enemyfollows enemy;

    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Enemy").GetComponent<BossStandarCode>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<CyclopRain>();
       // player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        //	enemy = gameObject.GetComponent<Rigidbody2D> ();
    }

    private void FixedUpdate()
    {
        if (cyclop == false)
        {
            boss.locatorlaser = onlocation;
        }
        else
        {
            enemy.locatorlaser = onlocation;
        }
    }
    void OnTriggerStay2D(Collider2D col)

        {
        if (col.isTrigger != true || col.CompareTag("locatormonster")) 
        {
            onlocation = true;
            enemy.locatorlaser = true;
            boss.locatorlaser = true;
           
        }
        if (col.isTrigger != true || col.CompareTag("locator"))
        {
            onlocation = true;
            enemy.locatorlaser = true;
            boss.locatorlaser = true;
        }

        
    }

    void OnTriggerEnter2D(Collider2D col)

    {
        if (col.isTrigger != true || col.CompareTag("locatormonster"))
        {
            onlocation = true;
            enemy.locatorlaser = true;

        }
        if (col.isTrigger != true || col.CompareTag("locator"))
        {
            onlocation = true;
            enemy.locatorlaser = true;
        }


    }

    void OnTriggerExit2D(Collider2D col)
    {
            onlocation = false;
            enemy.locatorlaser = false;
             boss.locatorlaser = false;
        }
    

}