using UnityEngine;
using System.Collections;

public class turetAI : MonoBehaviour {

	private Player user;
	public int curHealth;
	public int maxHealth;

	public float distance;
	public float shootinterval;
	public float wakerange;
	public float bulletTimer;
	public float bulletSpeed = 100;
	public int enemydefense = 10;
	public int speed = 3;
	public int Maxspeed = 4;
	private Rigidbody2D enemybody;


	public bool awake = false;
	public bool lookingRight = true;

	public GameObject bullet;
	public Transform target;
	public Animator anim;
	public Transform shootPointLeft;
	public Transform shootPointRight;


	void Awake()
	{

		anim = gameObject.GetComponent<Animator> ();
		enemybody = gameObject.GetComponent<Rigidbody2D>();
	}


	void Start()
	{
		user = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		curHealth = maxHealth;
	}



	void Update()

	{

		anim.SetBool ("Awake", awake);
		anim.SetBool ("lookright", lookingRight);
		RangeCheck ();

		if (target.transform.position.x > transform.position.x) 
		{
			transform.localScale = new Vector3(1,1,1);
			lookingRight = true;
			enemybody.AddForce((Vector2.right * Maxspeed) * distance);


		}

		if (target.transform.position.x < transform.position.x) 
		{
			enemybody.AddForce((Vector2.right * Maxspeed) * (distance*-1));
			transform.localScale = new Vector3(1,1,1);
			lookingRight = false;



		}

		if (enemybody.velocity.x > speed) {
			enemybody.velocity = new Vector2 (speed, enemybody.velocity.y);
		}
		if (enemybody.velocity.x < -speed) {
			enemybody.velocity = new Vector2 (-speed, enemybody.velocity.y);
		}

		//attacking punching kicking etc


		if (curHealth <= 0)

		{
			//en esta parte es que coje los exponentes
			user.Exp +=100;

			Destroy(gameObject);
		}

	}




	void RangeCheck()

	{
		distance = Vector4.Distance (transform.position, target.transform.position);

		if (distance < wakerange) 
		
				{

						awake = true;
				}
		if (distance > wakerange) 
		
				{
			awake = false;
				}

	}





	public void Attack(bool attackingRight)
	{
		bulletTimer += Time.deltaTime;

		if (bulletTimer >= shootinterval) 
		
		{
			Vector2 direction = target.transform.position - transform.position;

			direction.Normalize();

			if (!attackingRight)
			{
				GameObject bulletClone;
				bulletClone = Instantiate(bullet,shootPointLeft.transform.position, shootPointLeft.transform.rotation) as GameObject;
				bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
				bulletTimer = 0;
			}

			if (attackingRight)
			{
				GameObject bulletClone;
				bulletClone = Instantiate(bullet,shootPointRight.transform.position, shootPointLeft.transform.rotation) as GameObject;
				bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
				bulletTimer = 0;
			}
		}
	
	}




	public void Damage(int damage)

	{

		curHealth -=  (damage);
		gameObject.GetComponent<Animation>().Play("RedFlash 1");
	}
}
