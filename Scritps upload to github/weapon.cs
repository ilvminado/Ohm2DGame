using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{

    private Player  player;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float CoolDowntime = 1f;
    public float StartingTime = 0f;
    public float timer = 20f;
    private Animator anim;
    private bool shot;

    // Start is called before the first frame update

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();

    }
    void Update()
    {

        if (StartingTime == timer) // working perfect
        {

            StartingTime = 0;
        }
      
        if (Input.GetButtonUp("Fire5"))
        {

            shot = false;

        }

        if ((player.currenthealth > 0) && (StartingTime < CoolDowntime)) 
        
        {

            
            if (Input.GetButtonDown("Fire5"))
            {
                shot = true;
                anim.SetBool("shooting", shot);
                StartingTime += 1;
                Shoot();
               
               

            }
            
            
        }
        else
        {

         
                StartingTime += 1;
            
        }
       // StartingTime += 1;
        anim.SetBool("shooting", shot);
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }

    // Update is called once per frame
  
}
