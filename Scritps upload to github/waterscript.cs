using UnityEngine;
using System.Collections;

public class waterscript : MonoBehaviour {
	private Player player;
	//	private turetAI enemy;
	private enemyfollows enemy2;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void OnTriggerStay2D (Collider2D col)
		
	{
		
		if (col.CompareTag ("Player")) 
			
		{
			
			//player.Damage(1);

			//player.jumpPower -=10;
			StartCoroutine(player.Knockback(0.01f,50,player.transform.position));
			
		}
	}
	void OnTriggerEnter2D (Collider2D col)
		
	{
		
		if (col.CompareTag ("Player")) 
			
		{
			
			//player.Damage(1);
			
			//player.jumpPower -=10;
			StartCoroutine(player.Knockback(0.01f,50,player.transform.position));
			
		}
	}
}
