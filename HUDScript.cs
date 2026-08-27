using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour {


    //images an array variable for energy bar
	public Sprite[] HeartSprites;

	public Image HeartUI;

    //Audio FX for animations


    public Text lives;
    public Text level;
	public Text expshow2;
	public Text healthshow;
	public int levelshow ;
	public float expshow;
	private Player player;
	public float health;
    public Text enemycounter;
    
    public Text information;
    void Start () 
	{

		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}




		void Update()
		{
		expshow = player.Exp;
		levelshow = player.Level;
		level.text = levelshow.ToString();
		expshow2.text = expshow.ToString ();
		health = player.currenthealth;
		healthshow.text = health.ToString ();
        enemycounter.text = player.DeathCounter.ToString();
        information.text = player.information.ToString();
        lives.text = player.numberoflives.ToString();

        
		if (player.currenthealth >= (player.maxhealth *0.95))
		
		{
            
                        HeartUI.sprite = HeartSprites [0];
		}

       


		if (player.currenthealth < (player.maxhealth*0.90) && (player.currenthealth > (player.maxhealth*0.85)))
		{
			//level.text = levelshow.ToString ();
			
			HeartUI.sprite = HeartSprites [1];
		}
		if (player.currenthealth < (player.maxhealth*0.84) && (player.currenthealth > (player.maxhealth*0.75)))
		
		{
			
			HeartUI.sprite = HeartSprites [2];
		}

		if (player.currenthealth < (player.maxhealth*0.74) && (player.currenthealth > (player.maxhealth*0.65)))
			
		{
			
			HeartUI.sprite = HeartSprites [3];
		}


		if (player.currenthealth < (player.maxhealth*0.64) && (player.currenthealth > (player.maxhealth*0.55)))
			
		{
			
			HeartUI.sprite = HeartSprites [4];
		}

		if (player.currenthealth < (player.maxhealth*0.54) && (player.currenthealth > (player.maxhealth*0.45)))
		{
			
			HeartUI.sprite = HeartSprites [5];
		}

		if (player.currenthealth < (player.maxhealth*0.44) && (player.currenthealth > (player.maxhealth*0.35)))
		{
			
			HeartUI.sprite = HeartSprites [6];
		}


		if (player.currenthealth < (player.maxhealth*0.34) && (player.currenthealth > (player.maxhealth*0.25)))
		
		{
			
			HeartUI.sprite = HeartSprites [7];
		}

		if (player.currenthealth < (player.maxhealth*0.24) && (player.currenthealth > (player.maxhealth*0.15)))
			
		{
			
			HeartUI.sprite = HeartSprites [8];
		}
		if (player.currenthealth < (player.maxhealth*0.10) && (player.currenthealth > (player.maxhealth*0.00)))
			
		{
			
			HeartUI.sprite = HeartSprites [9];
		}
		}
	}



