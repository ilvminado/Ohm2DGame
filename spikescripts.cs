using UnityEngine;
using System.Collections;

public class spikescripts : MonoBehaviour {

	private Player player;
//	private turetAI enemy;
	private enemyfollows enemy2;
	// Use this for initialization
	int dmg = 20000;
	void Start () 
	{

	player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	//enemy =  GameObject.FindGameObjectWithTag ("Enemy").GetComponent<turetAI> ();

	}

	void OnTriggerEnter2D (Collider2D col)
	
	{

	if (col.CompareTag ("Player")) 
		    
			{

			player.Damage(player.maxhealth);
				
			//StartCoroutine(player.Knockback(0.02f,100,player.transform.position));

			}
	if (col.CompareTag ("Enemy")) //enemy gets damage.
		
			{
			col.SendMessageUpwards ("Damage",dmg);
			//StartCoroutine(enemyfollows.Knockback(0.02f,100,enemyfollows.transform.position));
			//enemy2.Damage(20);
			//enemy.Damage (10);
				}

	}

	void OnTriggerStay2D (Collider2D col)
		
	{
		
		if (col.CompareTag ("Player")) 
			
		{
            player.defending = false;
            player.dead = true;
		    player.Damage(player.maxhealth);
            
			
		//StartCoroutine(player.Knockback(0.02f,100,player.transform.position));
			
	}
		
	}

	
	// Update is called once per frame

}
