using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStandarCode : MonoBehaviour
{
    
    
    private Player user; //variable for the Target User , private
    
    public int curHealth;
    public int maxHealth = 1000;
    public float speed = 0; // was 15
    public float Maxspeed = 10;
    [Space(1)]
    [Tooltip("if Checked will have full AI ( by using parameters")]
    [Header("AI / or Manual Set of Movements")]
    public bool automatic = false; //if Checked will have full AI ( by using parameters)
    public bool abletoflip = false;
    public bool canfly;
    public Transform firePoint1;
    public Transform firePoint2;

    public GameObject bulletPrefab;
    public bool abletoshoot;
    public bool shots = false;
    //public bool movebackfoward;
    public float distanceitwillstopfromplayer =1f;
    public float counterdistanceframe = 200f;
    public float startcounterofframes = 0f;

    
    public bool moveup = true;
    public bool movedown = true;
    public bool moveright = true;
    public bool moveleft = true;
    public float distanceupdown;
    public float distance; //distance from the enemy to the user ( player Target) private uses the x position 
    //public float shootinterval;
    public float wakerange = 30;
    //public float bulletTimer;
    //public float bulletSpeed = 100;
    //public int enemydefense = 1;
    //public float Experience = 0
    public Rigidbody2D enemybody;
    //  [Space]
    [Space(1)]
    [Header("Use These Variables as parameters for Animators")]
    // [Header("Animation Variables")]
    [Tooltip("Animator Clip")]
    public Animator anim;
    public bool gethit = false;
    public bool checkup = false;
    public bool awake = false;
    public bool idler = false;
    public bool Dead = false;
    public bool attacking = false;
    public bool kicking = false;
    public bool attacking2 = false;
    public bool attackinglaser = false;
    public bool lookingRight = true;
    [Space(1)]
    // [Space]   
    [Header("Trigger Colliders")]
  //  [Header("Use these as parameters for Triggers")]

    [Tooltip("it checks for a player or object on top of this object")]
    public Collider2D upwardcheck;
    [Tooltip("it checks for a player or object in front of this object")]
    public Collider2D locatorPlayerTrigger;
    [Tooltip("shield for hitbox of this object, hitbox : collider where it takes damage")]
    public Collider2D hitboxshield;
    [Tooltip("hitbox of the object")]
    public Collider2D hitbox;
    [Tooltip("Collider that sends the damage to the player (triggered) ")]
    public Collider2D attacktrigger;
    [Tooltip("Collider on top of this object, that sends the damage to the player (triggered) ")]
    public Collider2D attackup;
    [Tooltip("Collider foward this object, that sends the damage to the player (triggered) ")]
    public Collider2D attackfoward;
    [Tooltip("Collider foward this object for the laser trigger, that sends the damage to the player (triggered) ")]
    public Collider2D laserattacktrigger;
    public bool locatorlaser;



    //Energy Bar inside the boss script


    // [information]
    //public GameObject bullet;
    [Tooltip("Game Object that this Object will follow , attack or such variables for x distances")]
    public Transform target;
 
    

    public Player player;
  
    //public Transform shootPointLeft;
    //public Transform shootPointRight;
    [Tooltip("Range of frames where things will execute, preferable less than 10 seconds/frames value")]
    public float CoolDowntime = 6f;//gives more time to enable the attack laser trigger to activate
   
    [Tooltip("Starting Time of the Timer, will increase until the Timer value")]
    public float StartingTime = 0f;
    
    [Tooltip("Maximun time until executing actions")]
    public float timer = 300f;
    



    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        enemybody = gameObject.GetComponent<Rigidbody2D>();
        hitboxshield.enabled = false;
        attacktrigger.enabled = false;
        laserattacktrigger.enabled = false;
        hitbox.enabled = true;
  
    }


    void Start()
    {
        user = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        curHealth = maxHealth;
        anim.SetBool("gettinghit", gethit);
        hitboxshield.enabled = true;
        shots = false;
        // locatorlaser2 = GameObject.FindGameObjectWithTag("location").GetComponent<LocatorLaser>();
    }



    void Update()

    {

        //l locatorlaser = locatorlaser2;
        // locatorlaser = GameObject.FindGameObjectWithTag("location").GetComponent<LocatorLaser>().onlocation;
        locatorlaser = GameObject.FindGameObjectWithTag("locator").GetComponent<LocatorLaser>().onlocation;

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

        if (gethit == false)
        {
           // speed =2;// was 13
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
            if (distance < 20)
            {
                StartingTime += 1;
            }
            if ((distance < 13f) && speed < 3)
            {
                anim.SetBool("walking", false);

                anim.SetBool("idle", true);
                // shots = true;
                

            }

            if ((distance < 100f) && (distance > 4f))
            {
                
                if (StartingTime >= timer) // working perfect
                {

                    StartingTime = 0;
                }

                anim.SetBool("walking", false);

                if (abletoshoot == false)
                {
                    if (((!attacking) && (StartingTime < 50)) && (locatorlaser))
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
                if (abletoshoot && distance < 40 && StartingTime < 2)
                {
                    
                        Shoot();
                    StartingTime += 1;

                }
                if (abletoshoot && distance > 20)
                {
                    StartingTime += 1;
                    // shots = false;
                }
            }

            if (distance > distanceitwillstopfromplayer && distance <= wakerange) //move following player back and foward X axis
            {
                // speed = 10;

                if (startcounterofframes == counterdistanceframe)
                {
                    startcounterofframes = 0;
                }

                anim.SetBool("walking", true);



                if (automatic == true)
                {
                    if ((user.transform.position.x + distanceitwillstopfromplayer > transform.position.x))
                    {
                        if (abletoflip)
                        {
                            transform.localScale = new Vector3(1, 1, 1);
                        }

                        lookingRight = true;
                        enemybody.AddForce((Vector2.right * Maxspeed) * (speed * 2)); //substitue distance from distancex
                                                                                          // attacking = false;

                        idler = false;
                        // attacktrigger.enabled = false;

                    }

                    if (user.transform.position.x - distanceitwillstopfromplayer < transform.position.x)
                    {

                       
                        lookingRight = false;

                        enemybody.AddForce((Vector2.right * Maxspeed) * ((speed * -1) * 2)); //substitue distance from distancexm
                        if (abletoflip)
                        {
                            transform.localScale = new Vector3(-1, 1, 1);
                        }
                        }
                    //  attacking = false;
                    //  attacktrigger.enabled = false;
                    // laserattacktrigger.enabled = false;

                    idler = false;


                }

                else //if automatic false (( this piece is to move back and foward in the manual ui)
                
                {
                    if (startcounterofframes == counterdistanceframe)
                    
                    {
                        startcounterofframes = 0;
                    }


                    if (moveup == true && (startcounterofframes > ((counterdistanceframe)/ 2) -5)) // value was - 15 or such / mass was 3, gravity 1 or 0.01 for left and right, counter distance frame was 300
                    {

                        //lookingup = true;
                        enemybody.AddForce((Vector3.up * Maxspeed) * (speed * 1));
                    }

                    if (movedown == true && (startcounterofframes < ((counterdistanceframe) / 2) - 5)) //this help with the timing in between movements ( total number divided by 2 minus an amount ) which will be the time in between movements
                    {

                        //lookingup = true;
                        enemybody.AddForce((Vector3.up * Maxspeed) * (speed * - 1));
                    }



                    if (moveright ==true && (startcounterofframes > 200))
                    {
                        lookingRight = true;
                        transform.localScale = new Vector3(1, 1, 1);
                        enemybody.AddForce((Vector2.right * Maxspeed) * (speed * 20));

                  
                                    
                   }

                    if (moveleft == true && (startcounterofframes < 200))
                    {
                    lookingRight = false;
                    transform.localScale = new Vector3(-1, 1, 1);
                    enemybody.AddForce((Vector2.right * Maxspeed) * (speed * -20));

                    }



                    startcounterofframes += 1;


                }





            }
            //enemy attacking --- still need to be fix
            if (distance <= 5f)
            {
                if (StartingTime == timer) // working perfect
                {

                    StartingTime = 0;
                }




                if ((!attacking) && (StartingTime < CoolDowntime))
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
           // speed = 0;
        }

    }

    void Die()
    {
       // user.Exp += Experience;
       // user.currenthealth += EnergyforPlayer;

        user.DeathCounter += 1;
        Destroy(gameObject);

    }


    void RangeCheck()

    {
        //locatorlaser = false;
        distance = Vector4.Distance(transform.position, target.transform.position); //it stores the distance between these two objects x value ( target is the player object ) 

        if (distance <= wakerange)

        {
            awake = true;
        }

        if (distance > wakerange)

        {
            awake = false;
        }


    }





 //   public void Attack(bool attackingRight)
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

   // }




    public void Damage(int Dmg)

    {
        if (curHealth > 0)
        {



            curHealth -= (Dmg);
            gethit = true;
            attacktrigger.enabled = false;
            anim.SetBool("walking", false);

            //this will make enemies Jump like a bounce Back
           // speed = 0;
            enemybody.AddForce(new Vector3(enemybody.velocity.x, 200));
          ///  enemybody.AddForce(new Vector2(enemybody.velocity.y, 500));
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
            //timer += Time.deltaTime;

            enemybody.AddForce(new Vector3(knockbackDir.x - 10 * 100, knockbackDir.y * knockbackPwr, transform.position.z));
            //rb2d.AddForce(new Vector3(knockbackDir.x * 100,knockbackDir.y * knockbackPwr, transform.position.z));


        }
        //Invoke ("idleani", 5);	
        //gethit = false;

        //knockback left


        yield return 0;
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
        Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);

    }

}
