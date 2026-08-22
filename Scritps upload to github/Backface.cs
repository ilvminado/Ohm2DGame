using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backface : MonoBehaviour
{

    private Player player;
    private enemyfollows enemy;
    // Use this for initialization
    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<enemyfollows>();
    }

    void OnTriggerEnter2D(Collider2D col)

    {
        if (col.CompareTag("Enemy"))
        {
            player.backface = true;

        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            player.backface = true;

        }
    }
    // Update is called once per frame

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            player.backface = false;

        }
    }



}
