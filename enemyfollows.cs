using UnityEngine;
using System.Collections;


public class enemyfollows : MonoBehaviour {

    private Player player;
    private Rigidbody2D playerbody;
    private Player user;
	public int curHealth ;
	public int maxHealth= 100;
	//private float attacktimer;
	//public float cooldown = 0.9f;
	public float distance;
	//public float shootinterval;
	public float wakerange;
	//public float bulletTimer;
	//public float bulletSpeed = 100;
	public int enemydefense = 1;
    public float Experience = 0;
    public int enemyattack = 5;
	public int speed = 2;
    public int EnergyforPlayer = 0;
	public int Maxspeed = 2;
	public Rigidbody2D enemybody;
    public bool grounded = false;
    public bool gethit = false;
    public bool collidingenemy = false;
    public bool awake = false;
	public bool idler = false;
    public bool Dead = false;
	public bool attacking = false;
	public bool lookingRight = true;
	public Collider2D attacktrigger;
    
	//public GameObject bullet;
	//public Transform target;

	public Animator anim;
    //public Transform shootPointLeft;
    //public Transform shootPointRight;

    public float CoolDowntime = 1f;
    public float StartingTime = 0f;
    public float timer = 20f;
    


    void Awake(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerbody = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator> ();
		enemybody = gameObject.GetComponent<Rigidbody2D>();
		attacktrigger.enabled = false;
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();


    }
	
	
	void Start()
	{
		user = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		curHealth = maxHealth;
        

    }
	
	
	
	void Update()
		
	{
        if (curHealth <= 0)
        {
            attacktrigger.enabled = false;
            Dead = true;
            anim.SetBool("dead", Dead);

            enemybody.mass = 20;

            // user.currenthealth += 400;


            Invoke("die", 2);

        }


        anim.SetBool ("idle", idler);
				//anim.SetBool ("Grounded", grounded);
				anim.SetFloat ("speed", speed);
//		anim.SetBool ("Awake", awake);
				anim.SetBool ("attack", attacking);
        //		anim.SetBool ("lookright", lookingRight);
               anim.SetBool("gethit", gethit);
        anim.SetBool("dead", Dead);
				RangeCheck ();
        gethit = false;

       
        //moves the enemy
        if ((Dead == false) && (gethit == false))
        {
            if (distance > 0.03f && distance <= wakerange)
            {
                speed = 2;
                if ((user.transform.position.x > transform.position.x))
                {

                    transform.localScale = new Vector3(1, 1, 1);
                    lookingRight = true;
                    enemybody.AddForce((Vector2.right * Maxspeed) * (distance*2));
                    attacking = false;
                    idler = false;
                    attacktrigger.enabled = false;
                }

                if (user.transform.position.x < transform.position.x)
                {

                    enemybody.AddForce((Vector2.right * Maxspeed) * ((distance * -1 )*2));
                    transform.localScale = new Vector3(-1, 1, 1);
                    lookingRight = false;
                    attacking = false;
                    attacktrigger.enabled = false;
                    idler = false;

                }





            }
            //enemy attacking --- still need to be fix
            if (distance <= 1.2f)
            {
                if (StartingTime == timer) // working perfect
                {

                    StartingTime = 0;
                }


                if ((!attacking) && (StartingTime < CoolDowntime))
                {



                    //attacktimer = cooldown;

                    attacktrigger.enabled = true;
                    idler = false;
                    attacking = true;
                    // attacktimer = +2;
                    StartingTime += 1;

                }
                else

                {
                    StartingTime += 1;
                    idler = true;
                    attacking = false;
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



        if (distance > wakerange )
		{
			idler = true;
			speed = 0;
		}

		}

    void die()
    {
        user.Exp += Experience;
        user.currenthealth += EnergyforPlayer;

        user.DeathCounter += 1;
        Destroy(gameObject);
        
    }
	
	
	void RangeCheck()
		
	{
		distance = Vector4.Distance (transform.position, player.transform.position);
		
		if (distance <= wakerange) 
			
		{
			awake = true;
		}

		if (distance > wakerange) 
			
		{
			awake = false;
		}
		
	}
	
	
	
	
	
	public void Attack(bool attackingRight)
	{
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
		
	}
	
	
	
	
	public void Damage(int Dmg)
		
	{
        if (curHealth > 0)
        {

           

            curHealth -= (Dmg);
            gethit = true;
            //this will make enemies Jump like a bounce Back
            enemybody.AddForce(new Vector3(enemybody.velocity.x, 100));
            //  enemybody.AddForce(new Vector3(enemybody.velocity.y, 100));
            enemybody.AddForce(new Vector2(transform.position.y, 100));
            //   gameObject.GetComponent<Animation>().Play("RedFlash 2");
            // gameObject.GetComponent<Animation>().Play("RedFlash 1");
            new WaitForSeconds(2);
            attacktrigger.enabled = false;
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
            timer += Time.deltaTime;

            enemybody.AddForce(new Vector3(knockbackDir.x - 10 * 100, knockbackDir.y * knockbackPwr, transform.position.z));
            //rb2d.AddForce(new Vector3(knockbackDir.x * 100,knockbackDir.y * knockbackPwr, transform.position.z));


        }
        //Invoke ("idleani", 5);	
        //gethit = false;

        //knockback left


        yield return 0;
    }

}

