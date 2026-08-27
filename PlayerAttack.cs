using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	private float attacktimer;
	private float cooldown = 0.7f;
	public bool doubleattack = false;
	private bool kicking = false;
	private bool attacking = false;
    private bool shot = false;
    private Player player;
	public Collider2D attacktrigger;
	public Collider2D uppunchtrigger;
	private Animator anim;

    public float attackRate = 5f;
    public float nextAttackTime = 3f;

	void Awake()
	{
		anim = gameObject.GetComponent<Animator> ();
		attacktrigger.enabled = false;
		uppunchtrigger.enabled = false;
        
       
    player = gameObject.GetComponentInParent<Player>();
	}

	void Update()

	{

        //fast
        ///Punching
        ///


        //   if (Time.time >= nextAttackTime)
        //   {
        //       if (Input.GetKeyDown("r") || Input.GetButtonDown("Fire1"))
        //       {
        //           attacking = true;

        //           nextAttackTime = Time.time + 1f / attackRate;
        //           anim.SetBool("Attacking", attacking);


        //       }



        //   }

if ((player.alive == true))
        {

     

            if ((Input.GetKeyDown("r") ||Input.GetButtonDown ("Fire1")) && !attacking) 
		        {	
						attacking = true;
						attacktimer = cooldown;
						attacktrigger.enabled = true;
						uppunchtrigger.enabled = true;
					//WaitForEndOfFrame;
				}

				if (attacking) {	
						if (attacktimer > 0)  
			                   
			            {
               
                attacktimer -= Time.deltaTime;

						} else {
								attacking = false;
								attacktrigger.enabled = false;
								uppunchtrigger.enabled = false; 
						}
						anim.SetBool ("Attacking", attacking);

		   
			           
				}

		///Punching2
		if ((Input.GetKeyDown("t") ||Input.GetButtonDown ("Fire2")) && !doubleattack) 
		{	
			doubleattack = true;
			attacktimer = cooldown;
			attacktrigger.enabled = true;
			uppunchtrigger.enabled = true;
			//WaitForEndOfFrame;
		}
		
		if (doubleattack) {	
			if (attacktimer > 0)  
				
			{
				
				attacktimer -= Time.deltaTime;
				
			} else {
				doubleattack = false;
				attacktrigger.enabled = false;
				uppunchtrigger.enabled = false; 
			}
			anim.SetBool ("Doubleattack", doubleattack);
			
			
			
		}
            //shotting

            if (Input.GetButton("Fire5"))
            {
                shot = true;

                //all of this code is in the weapon script ( for better update of variables)
            }
            else
            {
                shot = false;
                
            }
          //  anim.SetBool("shooting", shot);

            //kicking


            if ((Input.GetKeyDown("f") || Input.GetButtonDown("Fire3")) && !kicking)
				{	
					kicking = true;
					attacktimer = cooldown;
					attacktrigger.enabled = true;
					uppunchtrigger.enabled = true;
			//WaitForEndOfFrame;
			
				}
		
				if (kicking) 
				{	
					if (attacktimer > 0 )
					{
					attacktimer -= Time.deltaTime;
				
					}
				else
				{
					kicking = false;
					attacktrigger.enabled = false;
				    uppunchtrigger.enabled = false;
				}
			
				anim.SetBool("Kicking", kicking);
		}
		
	
		}


}
}
