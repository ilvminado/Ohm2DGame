using UnityEngine;
using System.Collections;

public class PlayerAttackTrigger : MonoBehaviour
{
    
    public int damg = 10;
    private enemyfollows enemy;
    // public Player enemy2;
    //private turetAI enemy2;




    void Start () 

    {

    enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent< enemyfollows>();
		//enemy2 =  GameObject.FindGameObjectWithTag ("Enemy").GetComponent<turetAI> ();
	}

  

    void OnTriggerEnter2D(Collider2D col)

	{
	

		if (col.isTrigger != true && col.CompareTag ("Enemy")) 
		
		{
            
            // enemy.Damage(damg);
            // enemy.Knockback2(0.01f, 0.2f, new Vector3(100f, 2f, 0.1f));
            col.SendMessageUpwards("Damage", damg);
            
            // enemy.Knockback2(0.01f, 0.2f, enemy.transform.position);
            //StartCoroutine(enemy.Knockback2(0.01f, 0.3f, enemy.transform.position));

            // enemy.transform.Translate(0.01f, 0.3f, 0.3f);




            // StartCoroutine(enemyvar.Knockback2(0.01f, 0.3f, enemyvar.transform.position));

            //nemy2.Damage(dmg);


        }
    }



    private void OnTriggerExit2D(Collider2D col)
    {


    }
}
