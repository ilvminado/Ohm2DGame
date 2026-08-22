using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class enemyenergybar : MonoBehaviour
{


    public SpriteRenderer energy;
    public Sprite [] energysprites;
    public enemyfollows enemy;
    // Start is called before the first frame update
    void Start()
    {
        // enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<enemyfollows>(); ;
        enemyfollows enemy = gameObject.GetComponent<enemyfollows>();
        energy = gameObject.GetComponent<SpriteRenderer>();
        energy.sprite = energysprites[0];
    
    }

    // Update is called once per frame
    void Update()
    {

        if (enemy.curHealth == enemy.maxHealth)
        {

            energy.sprite = energysprites[0];

        }

        if (enemy.curHealth < enemy.maxHealth * 0.70)
        {

            energy.sprite = energysprites[1];

        }

        if (enemy.curHealth < enemy.maxHealth * 0.50)
        {

            energy.sprite = energysprites[2];

        }
        if (enemy.curHealth < 1)
        {

            energy.sprite = energysprites[3];

        }


    }
}
