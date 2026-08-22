using UnityEngine;
using System.Collections;

public class enemyattacktrigger : MonoBehaviour {
public int dmg = 20;
private Player player;
    private enemyfollows enemy;
//	private enemyfollows enemy;

		void Start () 
	{
		
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
        
	//	enemy = gameObject.GetComponent<Rigidbody2D> ();
	}

	void OnTriggerEnter2D(Collider2D col)

	{
		if (col.isTrigger != true && col.CompareTag ("Player") )
		{
            //col.SendMessageUpwards ("Damage",dmg);
            
                player.Damage(dmg);
               
               // StartCoroutine(enemy.Knockback2(0.1f,0.3f, enemy.transform.position));
			    StartCoroutine(player.Knockback(0.1f,0.3f,player.transform.position));
            //	StartCoroutine(enemy.Knockback(0.01f,0.3f,enemy.transform.position));
            

        }
	}


}