using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclopRain : MonoBehaviour
{


    private Player user;
    public int curHealth;
    public int maxHealth = 1000;
    //private float attacktimer;
    //public float cooldown = 0.9f;
    public float distance;
    //public float shootinterval;
    public float wakerange =30;
    //public float bulletTimer;
    //public float bulletSpeed = 100;
    public int enemydefense = 1;
    public float Experience = 0;
    public int enemyattack = 40;
    public int speed = 3;
    public int EnergyforPlayer = 0;
    public int Maxspeed = 20;
    public Rigidbody2D enemybody;

    public bool gethit = false;

    public bool awake = false;
    public bool idler = false;
    public bool Dead = false;
    public bool attacking = false;
    public bool attackinglaser = false;
    public bool lookingRight = true;

    public Collider2D hitboxshield;
    public Collider2D attacktrigger;
    public Collider2D fireattacktrigger;
    public Collider2D missilesattacktrigger;
    public Collider2D laserattacktrigger;
    public Collider2D monsterbody;
    public Collider2D locatorPlayerTrigger;

    //Energy Bar inside the boss script


    
    //public GameObject bullet;
    public Transform target;
    public Animator anim;
    public Player player;
    //public Transform shootPointLeft;
    //public Transform shootPointRight;

    public float CoolDowntime = 6f;//gives more time to enable the attack laser trigger to activate
    public float StartingTime = 0f;
    public float timer = 100f;
    public float countdownlaser = 0f;
    public bool locatorlaser;
   // public bool locatorlaser2;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        enemybody = gameObject.GetComponent<Rigidbody2D>();
        hitboxshield.enabled = false;
       // locatorlaser2 = gameObject.GetComponent<LocatorLaser>();
        
        attacktrigger.enabled = false;
        laserattacktrigger.enabled = false;
        monsterbody.enabled = true;
        //locatorlaser = false;

    }


    void Start()
    {
        user = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        curHealth = maxHealth;
        anim.SetBool("gettinghit", gethit);
        hitboxshield.enabled = true;
        // locatorlaser2 = GameObject.FindGameObjectWithTag("location").GetComponent<LocatorLaser>();
    }



    void Update()

    {

        //l locatorlaser = locatorlaser2;
        // locatorlaser = GameObject.FindGameObjectWithTag("location").GetComponent<LocatorLaser>().onlocation;
        locatorlaser = GameObject.FindGameObjectWithTag("locator").GetComponent<LocatorLaser>().onlocation; //Gets Value from Class Locator laser Script added to the Trigger

        if (curHealth <= 0)
        {
            attacktrigger.enabled = false;
            Dead = true;

            laserattacktrigger.enabled = false;
            ////  anim.SetBool("dead", Dead);

            enemybody.mass = 20;

            // user.currenthealth += 400;
            Die();

           // Invoke("die", 2);

        }


        //enery bar function 

       

        //  anim.SetBool("idle", idler);
        //anim.SetBool ("Grounded", grounded);
        //  anim.SetFloat("speed", speed);
        //		anim.SetBool ("Awake", awake);
        //   anim.SetBool("attack", attacking);
        //		anim.SetBool ("lookright", lookingRight);
        //  anim.SetBool("gethit", gethit);
        //   anim.SetBool("dead", Dead);
        
        anim.SetBool("gettinghit", gethit);
        RangeCheck();
        gethit = false;
        //anim.SetBool("gettinghit", gethit);

        if (distance < 35) //will only get hit at certain distance there is a Box2d Shielding the hit box
        {
            hitboxshield.enabled = false;
        }
        //moves the enemy
        if ((Dead == false) && (gethit == false))
        {

            if (distance > 50f)

            {
                
                    anim.SetBool("walking", false);

                    anim.SetBool("idle", true);

                

                if (StartingTime == timer) // working perfect
                {

                    StartingTime = 0;
                }
                else
                {

                   //when taking this one out laser constant// StartingTime += 1;
                  //  idler = true;
                    laserattacktrigger.enabled = false;
                    attackinglaser = false;
                  //  missilesattacktrigger.enabled = false;
                    anim.SetBool("laser", attackinglaser);
                    //anim.SetBool("walking", true);

                }

                //  if ((!attacking) && (StartingTime < CoolDowntime))

                //   {
                //     StartingTime += 1;
                //  }


            }
            if ((distance < 8f) && speed < 3)
            {
                anim.SetBool("walking", false);

                anim.SetBool("idle", true);

            }

            if ((distance < 25f) && (distance > 9f))
            {
                 if (StartingTime == timer) // working perfect
                   {

                     StartingTime = 0;
                  }

                anim.SetBool("walking", false);


                if (((!attacking) && (StartingTime < CoolDowntime)) && (locatorlaser))
                {

                    //countdownlaser += 1;
                    

                    anim.SetBool("laser", true);
                    StartingTime += 1;
                    attackinglaser = true;
                    laserattacktrigger.enabled = true;
                    // missilesattacktrigger.enabled = true;
                    
                   // player.Damage(50);
                    
                    
                   
                }


                else
                {

                    StartingTime += 1;
                   // idler = true;
                    //countdownlaser -= 0.1f;
                    laserattacktrigger.enabled = false;
                   // missilesattacktrigger.enabled = false;

                    attackinglaser = false;
                    //locatorPlayerTrigger.enabled = false;
                    anim.SetBool("laser", false);
                   // Invoke("RangeCheck",2);

                }
                

            }

            if (distance > 7f && distance <= wakerange)
            {
                speed = 2;

                
                
                    anim.SetBool("walking", true);
                
               



                if ((user.transform.position.x > transform.position.x))
                {

                    transform.localScale = new Vector3(1, 1, 1);
                    lookingRight = true;
                    enemybody.AddForce((Vector2.right * Maxspeed) * (distance * 2));
                   // attacking = false;

                    idler = false;
                   // attacktrigger.enabled = false;
                }

                if (user.transform.position.x < transform.position.x)
                {

                    enemybody.AddForce((Vector2.right * Maxspeed) * ((distance * -1) * 2));
                    transform.localScale = new Vector3(-1, 1, 1);
                    lookingRight = false;
                  //  attacking = false;
                  //  attacktrigger.enabled = false;
                   // laserattacktrigger.enabled = false;

                    idler = false;

                }

               




            }
            //enemy attacking --- still need to be fix
            if (distance <= 9f)
            {
                if (StartingTime == timer) // working perfect
                {

                    StartingTime = 0;
                }

                


                if ((!attacking) && ((StartingTime)/2 < CoolDowntime))
                {



                    //attacktimer = cooldown;
                    laserattacktrigger.enabled = false;
                    anim.SetBool("laser", attackinglaser);

                    attacktrigger.enabled = true;
                    idler = false;
                    attacking = true;
                    // attacktimer = +2;
                    StartingTime += 1;
                    //countdownlaser = 0;

                }
                else

                {

                    StartingTime += 1;
                    idler = true;
                    attacking = false;
                    attacktrigger.enabled = false;
                    laserattacktrigger.enabled = false;
                    
                        anim.SetBool("walking", false);

                        anim.SetBool("idle", true);

                    
                    // anim.SetBool("laser", attackinglaser);
                }



                //  if (attacking)
                //  {
                //  if (attacktimer > 0)
                //  {
                //     attacktimer -= 1;
                //     idler = true;
                //     attacking = false;
                // //gameObject.GetComponent<Animation>().Play("walk");


                //  }
                //   else
                //  {
                //   attacking = false;
                //  attacktrigger.enabled = false;
                // //idler = true;

                //  }

                /////anim.SetBool ("Attacking", attacking);
                /// //	attacking = true;
                /// //cooldown = 1000f;
                // //	attacktrigger.enabled = true;
                // }


                //attacktrigger.enabled = true;
                //attacking =true;
                //attacktrigger.enabled = false;
            }


            if ((distance <= wakerange) && (!gethit))
            {
                if (enemybody.velocity.x > speed)
                {
                    enemybody.velocity = new Vector2(speed, enemybody.velocity.y);
                }
                if (enemybody.velocity.x < -speed)
                {
                    enemybody.velocity = new Vector2(-speed, enemybody.velocity.y);

                }

                //attacking punching kicking etc

                //die


            }

        }
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;


        }



        if (distance > wakerange)
        {
            
            anim.SetBool("idle", true);
            idler = true;
            speed = 0;
        }

    }

    void Die()
    {
        user.Exp += Experience;
        user.currenthealth += EnergyforPlayer;

        user.DeathCounter += 1;
        Destroy(gameObject);

    }


    void RangeCheck()

    {
        //locatorlaser = false;
        distance = Vector4.Distance(transform.position, target.transform.position);

        if (distance <= wakerange)

        {
            awake = true;
        }

        if (distance > wakerange)

        {
            awake = false;
        }

        
    }





  //  public void Attack(bool attackingRight)
  //  {
        //bulletTimer += Time.deltaTime;

        //	if (bulletTimer >= shootinterval) 

        //	{
        //		Vector2 direction = target.transform.position - transform.position;

        //		direction.Normalize();

        //	if (!attackingRight)
        //	{
        //		GameObject bulletClone;
        //		bulletClone = Instantiate(bullet,shootPointLeft.transform.position, shootPointLeft.transform.rotation) as GameObject;
        //		bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        //		bulletTimer = 0;
        //	}

        //	if (attackingRight)
        //	{
        //		GameObject bulletClone;
        //		bulletClone = Instantiate(bullet,shootPointRight.transform.position, shootPointLeft.transform.rotation) as GameObject;
        //		bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        //	bulletTimer = 0;
        //	}
        //}

  //  }




    public void Damage(int Dmg)

    {
        if (curHealth > 0)
        {



            curHealth -= (Dmg);
            gethit = true;
            attacktrigger.enabled = false;
            anim.SetBool("walking", false);

            //this will make enemies Jump like a bounce Back

            enemybody.AddForce(new Vector3(enemybody.velocity.x, 50));
            enemybody.AddForce(new Vector2(enemybody.velocity.y, 50));
         ///   enemybody.AddForce(new Vector2(transform.position.y, 100));
            //   gameObject.GetComponent<Animation>().Play("RedFlash 2");
            // gameObject.GetComponent<Animation>().Play("RedFlash 1");
            new WaitForSeconds(5);

            

        }

    }



    public IEnumerator Knockback2(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {

        float timer = 0;
        enemybody.velocity = new Vector2(enemybody.velocity.x, 0);


        //Determines wheter the enemy is facing Right or Left before getting hit, so it can be bounce back in the correct direction.
        enemybody.AddForce(new Vector3(knockbackDir.x - 10 * 100, knockbackDir.y * knockbackPwr, transform.position.z));


        if (knockDur > timer && lookingRight == false)

        //knockback right

        {
            gethit = true;
            timer += Time.deltaTime;
            enemybody.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y * knockbackPwr, transform.position.z));


            //gethit = true;

        }


        if (knockDur > timer && lookingRight == true)

        //knockback left
        {

            gethit = true;
           // timer += Time.deltaTime;

            enemybody.AddForce(new Vector3(knockbackDir.x - 10 * 100, knockbackDir.y * knockbackPwr, transform.position.z));
            //rb2d.AddForce(new Vector3(knockbackDir.x * 100,knockbackDir.y * knockbackPwr, transform.position.z));


        }
        //Invoke ("idleani", 5);	
        //gethit = false;

        //knockback left


        yield return 0;
    }

}


