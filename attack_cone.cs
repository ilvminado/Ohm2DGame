using UnityEngine;
using System.Collections;

public class attack_cone : MonoBehaviour {
	
	public turetAI TurretAI;
	public bool isleft = false;
	// Use this for initialization
	void Awake () 
	{
		TurretAI = gameObject.GetComponentInParent<turetAI>();
	}
	
	// Update is called once per frame
	void OnTriggerStay2d (Collider2D col) 
	{
		
		if (col.CompareTag("Player"))
		{
			
			if (isleft)
			{
				TurretAI.Attack(false);
			}
			else
			{
				TurretAI.Attack(true);
				
			}
		}
		
	}
}
