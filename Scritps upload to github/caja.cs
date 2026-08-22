using UnityEngine;
using System.Collections;

public class caja : MonoBehaviour {


	//	private turetAI enemy;
//	private enemyfollows enemy2;
	// Use this for initialization
	int dmg = 40;
	void Start () 
	{
		

		//enemy =  GameObject.FindGameObjectWithTag ("Enemy").GetComponent<enemy> ();
		
	}
	
	void OnTriggerEnter2D (Collider2D col)
		
	{
		
	
		if (col.CompareTag ("Enemy")) //enemy gets damage.
			
		{
			col.SendMessageUpwards ("Damage",dmg);
			//StartCoroutine(enemy2.Knockback(0.02f,100,enemy2.transform.position));		
		}
		
	}
	
	void OnTriggerStay2D (Collider2D col)
		
	{
		
		if (col.CompareTag ("Enemy")) 
			
		{
			

			
			
			col.SendMessageUpwards ("Damage",dmg);
			
		}
		
	}
}
