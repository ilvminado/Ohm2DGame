using UnityEngine;
using System.Collections;

public class hachaspick : MonoBehaviour {
	private Player user;
	
	// Use this for initialization
    //This Script is used to Transform the player into another animations or sprite when this object is  pickup
	void Start () 
	{
		//player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		user = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		
	}
	
	// Update is called once per frame
	
	
	void OnTriggerStay2D (Collider2D col)
		
	{
		
		if (col.CompareTag ("Player") &&  (Input.GetButtonDown("Fire3")) && (user.facingRight))
		    {

										user.transformer = true;
										user.Invoke ("idleani", 2);
										Destroy (gameObject); 
								}

		if (col.CompareTag ("Player") &&  (Input.GetKeyDown(KeyCode.DownArrow)) && (user.facingRight))
		{
			
			user.transformer = true;
            user.abletofly = true;
            user.Invoke ("idleani", 2);
			Destroy (gameObject); 
		}

						}
			}
		

