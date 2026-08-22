using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
//This class if Added to an object will give the ability to add values to the player from the item list
//This class can be modified but also the player class has to be modified with the number of items or lists that the user wants to add. 
{
    private Player user;

    // Use this for initialization
    Camera maincamera;
    public int keymap = 0;
    public int keymap2 = 0;
    public int key = 0;
    public int health = 1000;
    public int locator = 0;
    public int shippieces = 0;
    public int sizeofcamera = 0;
    public float smoothtransition;
    public float count;

    public bool isacheckpoint = false;
    public float xcoord;
    public float ycoord;

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
        user = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        maincamera = Camera.main;
        count = maincamera.orthographicSize; //size of main camera

        xcoord = (transform.position.x);
        ycoord = (transform.position.y);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

    }

    void OnTriggerEnter2D(Collider2D col)

    {

        if (col.CompareTag("Player"))

        {
            if (smoothtransition < sizeofcamera)
            {
                for (smoothtransition = count; smoothtransition < sizeofcamera; smoothtransition++) //counter goes from size of main camera until it reach size you want 
                {
                    maincamera.orthographicSize += 0.50f;

                }

            }

            if (isacheckpoint == true)
            {
                  user.xcoord = xcoord;
                  user.ycoord = ycoord;
            }

            user.maxhealth += health;
            user.currenthealth += health;

            // user.keymap1 = keymap;
            // user.keymap2 = keymap2;
            // user.locatorgps = locator;
            // user.shippieces = shippieces;
            if (smoothtransition == sizeofcamera)
            {
                Destroy(gameObject);
            }
        }
    }
}