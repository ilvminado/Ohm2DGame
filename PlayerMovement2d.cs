using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement2d : MonoBehaviour
{

    //Script Created by Claudio Ivan Sanchez 05/20/2020 for the concept of a 2d game

    //this Script will give player movement when the player is found to be alive, will check on booleans for it and proceed to move in reference to 
    //key inputs while refreshing in the frames
    // when code attach to sprite/ rigibody2d and animator are to be private for this instance only.
    public float speed = 40f;
    public float maxSpeed = 2f;

    public bool alive = true;
    public float currenthealth ;
    public float maxhealth = 100;
    public bool facingRight;
    public bool dead = false;

    private Rigidbody2D player;
    private Animator animPlayer;


    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxhealth;
        player = gameObject.GetComponent<Rigidbody2D>();
        animPlayer = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //check if player is alive

       

            if (alive) 
            {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            Debug.Log(h);
            Debug.Log(speed);

            if (Input.GetAxis("Horizontal") < -0.1f)

                {
                    transform.localScale = new Vector3(-0.5f, 0.5f, 1);//flips the player
                    facingRight = false;
                    player.AddForce((Vector2.right * speed) * h);//function that moves the player foward


            }
            if (Input.GetAxis("Horizontal") > 0.1f)
                {
                    transform.localScale = new Vector3(0.5f, 0.5f, 1);
                    facingRight = true;
                    player.AddForce((Vector2.right * speed) * h);//function that moves the player back

            }


            if (Input.GetAxis("Vertical") >-0.1f) //function that moves up the player
                {
                player.AddForce((Vector2.up * speed) * v);

                }

            if (Input.GetAxis("Vertical") > 0.1f)//function that moves down when press down
            {
                player.AddForce((Vector2.down * speed) *v);

            }



            if (currenthealth > maxhealth)
                {
                    currenthealth = maxhealth;
                }

                if (currenthealth <= 0)
                {
                    dead = true;
                    alive = false;
                    //   Invoke("Die", 5);//this will happen after 40 seconds
                    //Die();
                }



                //movingplayer

               

                //max velocity
                if (player.velocity.x > maxSpeed)
                {
                    player.velocity = new Vector2(maxSpeed, player.velocity.y);
            }
                if (player.velocity.x < -maxSpeed)
                {
                    player.velocity = new Vector2(-maxSpeed, player.velocity.y);

            }




        }
        }

  

        //class when invoked will reload the game in the currentlevel

        void Die()

        {
        SceneManager.LoadScene(0);

        //Application.LoadLevel(Application.LoadLevel);

        }


    }




