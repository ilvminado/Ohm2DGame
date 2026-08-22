using UnityEngine;
using System.Collections;

public class rotator : MonoBehaviour {
	private Player player;
	private enemyfollows enemy2;
	//public Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		//rb2d = gameObject.GetComponent<Rigidbody2D>();
	}

	void OnTriggerEnter2D (Collider2D col)
		
	{
		
				if (col.CompareTag ("Player")) {

			if (Input.GetKeyDown ("r"))
			           {

						player.transform.position = new Vector3(-30f,5.34f,10f);
			            
			           }
			
				}
		}

	void OnTriggerStay2D (Collider2D col)
		
	{
		if (col.CompareTag ("Player")) {

			if (Input.GetKeyDown ("r"))
			{
				player.transform.position = new Vector3(-30f,5.34f,10f);;
				
			}
			//player.transform.position = new Vector3(9,20,10);
			//player.transform.Rotate (0,0,90);
			
			
			
		}


		}
	// Update is called once per frame

}
