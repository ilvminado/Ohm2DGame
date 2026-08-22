using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnergyBar : MonoBehaviour
{


    public SpriteRenderer energy;
    public Sprite[] energysprites;
    public CyclopRain enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        // enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<enemyfollows>(); ;
        CyclopRain enemy = gameObject.GetComponent<CyclopRain>();
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

        if (enemy.curHealth < enemy.maxHealth * 0.95)
        {

            energy.sprite = energysprites[1];

        }
        if (enemy.curHealth < enemy.maxHealth * 0.85)
        {

            energy.sprite = energysprites[2];

        }

        if (enemy.curHealth < enemy.maxHealth * 0.75)
        {

            energy.sprite = energysprites[3];

        }

        if (enemy.curHealth < enemy.maxHealth * 0.65)
        {

            energy.sprite = energysprites[4];

        }


        if (enemy.curHealth < enemy.maxHealth * 0.50)
        {

            energy.sprite = energysprites[5];

        }
        if (enemy.curHealth < enemy.maxHealth * 0.40)
        {

            energy.sprite = energysprites[6];

        }

        if (enemy.curHealth < enemy.maxHealth * 0.30)
        {

            energy.sprite = energysprites[7];

        }
        if (enemy.curHealth < enemy.maxHealth * 0.10)
        {

            energy.sprite = energysprites[7];

        }

        if (enemy.curHealth < 1)
        {

            energy.sprite = energysprites[8];

        }


    }
}
