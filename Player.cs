using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	public float speed = 42f;
	public float maxSpeed = 2f;
	public float jumpPower = 400f;

    //List of items that the player can take //use health script or item script to do;

    public int shippieces = 0; //need 5 pieces from the map to proceed last boss
    public int locatorgps = 0; //need 1 locatorgps to kill boss monster
    public int keymap1 = 0; //need keymap1 to continue level progress, boss 1 gives key;
    public int keymap2 = 0; //need keymap2 to continue level progress, boss 2 gives key;
    public float xcoord = -207.74f;
    public float ycoord = 8.31f;
    //Character variables for stats starting game and maximum  levels and others.
    public float Hitpoints = 100f;
	public int playerlevel= 99;
	public float MagicPoints = 10f;
	public float Exp = 0f;
	public float AbilityPoints = 10f;
	public int AttackPower = 30;
	public int defensePower = 100;
	public float MagicPower = 10f;
	public float MagicEvasion = 10f;
	public float Stamina = 10f;
	public float Luck = 10f;
    public int DeathCounter = 0;
    public float GameOver = 0f;
	public float TimerGame = 0f;
	public int currenthealth ;
	public int maxhealth = 400;
	public bool facingRight = true;
	public bool transformer = false;
	public int Level = 5;

    public String information = "Important Information Here";
    //ends character variables

    // wall sliding , double jump, grounded , rigibody animatior others
    public bool wallsliding = false;
	public bool candoblejump;
    public bool backface = false;
	public bool grounded = false;
    public bool abletofly = false;

	private Rigidbody2D rb2d;
	private Animator anim;
     CapsuleCollider2D Collider_m;
  //  private AudioSource AudioMng;

    public bool wallslider = false;

	public double timersion = 0;
	public Transform wallCheckPoint;
	public Transform waterCheckPoint;
	public bool dead = false;
	public bool wallCheck = false;
	public bool waterCheck;
	public LayerMask waterLayerMask;
	public LayerMask wallLayerMask;
    public int numberoflives = 3;
	public bool gethit = false;
    public bool abajarse = false;
    public bool alive = true;

    //working in progress

    public bool trance;
    public bool defending = false;


    // Use this for initialization
    void Start () 
	{
		currenthealth = maxhealth;
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator> ();
        Collider_m = GetComponent<CapsuleCollider2D>();
        information = "Important Information Here";

    }

    // Update is called once per frame
    void Update () 
	{
        if (currenthealth > maxhealth)
        {
            currenthealth = maxhealth;
        }

                anim.SetBool ("dead", dead); //play animation dead
				anim.SetBool ("sliding", wallCheck);
				//anim.SetBool ("swimming", swimmingcheck);
				anim.SetBool ("gettinghit", gethit);
				anim.SetBool ("Grounded", grounded);
                anim.SetBool ("abajarse", abajarse);
		        anim.SetBool ("Sable",transformer);
                anim.SetBool("DoubleJump", candoblejump);
                anim.SetFloat("otherSpeed", speed);
                anim.SetBool("Defending", defending);

                anim.SetFloat ("Speed", Mathf.Abs (Input.GetAxis ("Horizontal")));
                rb2d.gravityScale = 1;
             
        //working
        


        if (alive) {

            

            if (Input.GetKeyUp("q"))
            {
                defending = false;
                
            }
            

            if ((Input.GetKeyUp("u") || ( Input.GetButtonUp("Fire6"))))
            {

                speed = 80f;
                maxSpeed = 3f;
            }


            //flip sprite // function to flip the sprite on the x axis
            //Old Way but the shooting was not working correctly // if (Input.GetAxis ("Horizontal") < -0.1f) 
            if ((Input.GetKeyDown(KeyCode.LeftArrow) && facingRight) || (Input.GetAxis("Horizontal") < - 0.1f) && facingRight)
            {
                // oldway /transform.localScale = new Vector3 (-0.5f, 0.5f, 1);
                transform.Rotate(0f, 180f, 0f);				
                facingRight = false;
						}
			//			old way// if (Input.GetAxis ("Horizontal") > 0.1f) 
            if ((Input.GetKeyDown(KeyCode.RightArrow) && !facingRight) || (Input.GetAxis ("Horizontal") > 0.1f) && !facingRight)
            {
                //oldwayt // transform.localScale = new Vector3 (0.5f, 0.5f, 1);
                transform.Rotate(0f, 180f, 0f);				
                facingRight = true;
						}




            if (Input.GetKey(KeyCode.DownArrow))

            // (Input.GetKey(KeyCode.DownArrow))
            {
                abajarse = true;
                anim.SetBool("abajarse", abajarse);

            }
            abajarse = false;

            //function to jump makes the sprite jump

            if (Input.GetButtonDown ("Jump")) {

								if (grounded) {

										grounded = false;
										rb2d.AddForce (Vector2.up * jumpPower);
										candoblejump = true;

								} else {

										if (candoblejump) {
												grounded = false;
												candoblejump = false;
												rb2d.velocity = new Vector2 (rb2d.velocity.x, 0);
												rb2d.AddForce (Vector2.up * jumpPower);
										}

										wallsliding = false;

								}
			

						}
				}



	//energia y otros / energy and others
    // Compare energy calls function DEAD if less than 0, invoke  (timer ) for the animation DEAD
	

	if (currenthealth <= 0) {
						    dead = true;
						    alive = false;
						    Invoke ("Die", 2);//this will happen after 2 seconds
						//Die();
				             }

        
   
        

        //wall sliding handled starts here 
        //maybe i should write all this code on the x axis movement 

        if (alive) {

            if (!grounded && wallCheck ) {
								//wallCheck = Physics2D.OverlapCircle (wallCheckPoint.position, 0.1f, wallLayerMask);

                                HandlewallSliding();
								if (!facingRight && Input.GetAxis ("Horizontal") > 0.1f || facingRight && Input.GetAxis ("Horizontal") < 0.1f) {


										if (wallCheck) {
                        
                                        HandlewallSliding ();
												//candoblejump = true;
										}

										if ((wallCheck = false) && (grounded)) {
												wallsliding = false;
												grounded = false;
										}

                                        if (!wallCheck )
                                         {
                                         wallsliding = false;
                                        }

								}
                
                grounded = false;
				
						}


				}
		}

      







	    void HandlewallSliding()
	    {
        //reduces the velocity of the player , gravity goes to zero everytime he is on the wall and pressing foward
				rb2d.velocity = new Vector2 (rb2d.velocity.x, -0.1f);
                candoblejump = true;
				wallsliding = true;
                grounded = false;
                defending = false;
				if (alive) {
                        rb2d.gravityScale = 0;

						if (Input.GetButtonDown ("Jump")) {
								if (facingRight) {
									//	wallslider = true;
										rb2d.AddForce (new Vector2 (-2, 0.1f * jumpPower / 4));

								} else {
									//		wallslider = true;
										rb2d.AddForce (new Vector2 (2, 0.1f * jumpPower / 4));

								}

						}
				}
        

    }
    void FixedUpdate()

    {
       
        gethit = false;
        
        Vector3 easevelocity = rb2d.velocity;
        easevelocity.y = rb2d.velocity.y;
        easevelocity.z = 0.0f;
        easevelocity.x *= 0.70f;
        
        // function to move up and down, fake z movement on Y 

        //float v = Input.GetKeyUp;
        if (alive)
        {



            if (Input.GetKey(KeyCode.UpArrow) && wallsliding)
            {


              //  rb2d.transform.position = new Vector3(rb2d.transform.position.x, rb2d.transform.position.y + 0.2f, rb2d.transform.position.z);
                //player.transform.position = new Vector3(Player.transform.position.x,Player.transform.position.y+1,Player.transform.position.z);
            }

        }

        //player.transform.position = new Vector3(9,20,10);

        //getaxis Horizontal  move the character back and foward 
        ///funciona para esperar un input de las teclas horizontales atras alante .
        float h = Input.GetAxis("Horizontal");


        if ((alive))
        {

                                

            if ((grounded) && ((Input.GetKey("u") || Input.GetButton("Fire6")))) //RightT Xbox
            {

                speed = 200f;
                maxSpeed = 4f;
             }
           

            if (grounded)
            {
                rb2d.velocity = easevelocity;
            }

            ///
            if (grounded)
            {
                rb2d.AddForce((Vector2.right * speed) * h);


            }
            else
            {
                rb2d.AddForce((Vector2.right * speed / 2) * h);

            }
        }
        //movingplayer

        //  Debug  .  Log(h)
        //  Debug  .  Log(speed)

        //max velocity


        if (rb2d.velocity.x > maxSpeed)
            {
                rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);

            }
            if (rb2d.velocity.x < -maxSpeed)
            {
                rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);



            }




        }


    public void Damage(int Dmg)

    {

        if (defending == false)

        {
            if ((currenthealth > 1))
            {
                anim.SetBool("gettinghit", gethit);
                gethit = true;

                currenthealth -= (Dmg);
                //   gameObject.GetComponent<Animation>().Play("getting hit 1");

            }

            else
            {
                numberoflives = numberoflives - 1;


                if (numberoflives == 0)
                {
                    alive = false;

                    Die();
                    dead = true;
                }
               alive = true;
               dead = false;
               rb2d.position = new Vector2 (rb2d.position.x, xcoord);
               rb2d.position = new Vector2 (rb2d.position.y, ycoord);
               currenthealth = 1000;

            }
            //gameObject.GetComponent<Animation>().Play("getting hit");
            //gameObject.GetComponent<SpriteRenderer>().color = new Color (255,255,255,255) ;
        }
        else
        {
            gethit = false;

        }
        
    }

    void Die()

	            {

        
      
        if (numberoflives == 0)     
        {
            dead = true;
            Application.Quit();
            // SceneManager.LoadScene(0); /// or first level load dead scene
        }
        
       // Application.LoadLevel(Application.loadedLevel );

    }

	

    

    // knock back force when player get hit, this function send the player back
    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir){

		float timer = 0;
		rb2d.velocity = new Vector2 (rb2d.velocity.x, 0);

        //Determines wheter the player is facing Right or Left before getting hit, so it can be bounce back in the correct direction.

        //If the player is facing Right and there is an attack on his back he has to Jump Foward Right
        if (knockDur > timer && facingRight == true && backface)

        {

           // gethit = true;
            timer += Time.deltaTime;
            // rb2d.IsSleeping();

            rb2d.AddForce(new Vector3(knockbackDir.x * -20, knockbackDir.y * knockbackPwr, transform.position.z));

        }

        //If the player is facing left and there is no attack on his back, he jumps right
            if (knockDur > timer && (!facingRight && !backface)) 
		
		//knockback right

		{
            //gethit = true;
            timer += Time.deltaTime;
            // rb2d.IsSleeping();
            
            rb2d.AddForce(new Vector3(knockbackDir.x * -10,knockbackDir.y * knockbackPwr, transform.position.z));
           // Collider_m.enabled = !Collider_m.enabled;
            // rb2d.IsAwake();
            //Collider_m.enabled = true;


            //gethit = true;

        }
            //if the player is facing Right and there is no back attack he jumps left

		if (knockDur > timer && ( facingRight == true && !backface)) 
			
			//knockback left
		{
            
            //gethit = true;
            //timer += Time.deltaTime;
            // rb2d.IsSleeping();
            
            rb2d.AddForce(new Vector3(knockbackDir.x * 10, knockbackDir.y * knockbackPwr, transform.position.z));
           // Collider_m.enabled = !Collider_m.enabled;
            //rb2d.AddForce(new Vector3(knockbackDir.x * 100,knockbackDir.y * knockbackPwr, transform.position.z));
            //rb2d.IsAwake();
           // Collider_m.enabled = true;
        }

        //if the player is facing left and there is an attack on his back he jumps left
        if (knockDur > timer && (!facingRight && backface))

        //knockback left
        {

            //gethit = true;
            //timer += Time.deltaTime;
            // rb2d.IsSleeping();

            rb2d.AddForce(new Vector3(knockbackDir.x * 20, knockbackDir.y * knockbackPwr, transform.position.z));
            // Collider_m.enabled = !Collider_m.enabled;
            //rb2d.AddForce(new Vector3(knockbackDir.x * 100,knockbackDir.y * knockbackPwr, transform.position.z));
            //rb2d.IsAwake();
            // Collider_m.enabled = true;
        }

        //Invoke ("idleani", 5);	
        //gethit = false;

        //knockback left
        //  Collider_m.enabled = true;

        yield return 0;
	}


}
