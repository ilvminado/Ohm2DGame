using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{


        private Player player;
        private Rigidbody2D playerbody;
        public Transform spawnpoint;
        public GameObject enemytospawn;
        public int countermonsters = 0;
        public int maxnumbermonsters = 4;
        
        public float distance;
        public float wakerange;
        public bool awake = false;
        public float CoolDowntime = 1f;
        public float StartingTime = 0f;
        public float timer = 20f;
        private Animator anim;
      //  private bool spawn = false;

        // Start is called before the first frame update

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            playerbody = gameObject.GetComponent<Rigidbody2D>();
        //    anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
      //      spawn = false;
        RangeCheck();
            
        }
    void Update()
    {

        if (distance < wakerange)

        {
            if (StartingTime == timer) // working perfect
            {

                StartingTime = 0;
            }

            if (countermonsters > maxnumbermonsters)
            {

        //        spawn = false;

            }

            if ((player.currenthealth > 0) && (StartingTime < CoolDowntime) && (countermonsters < maxnumbermonsters))

            {


              
         //           spawn = true;
                   // anim.SetBool("shooting", shot);
                    StartingTime += 1;
                    Spawner();
                    countermonsters += 1;



            }
            else
            {


                StartingTime += 1;

            }
           // anim.SetBool("shooting", shot);
        }
    }
    void RangeCheck()

    {
        distance = Vector4.Distance(transform.position, player.transform.position);

        if (distance <= wakerange)

        {
            awake = true;
        }

        if (distance > wakerange)

        {
            awake = false;
        }

    }
    void Spawner()
        
        {
            Instantiate(enemytospawn, spawnpoint.position, spawnpoint.rotation);

        }

        // Update is called once per frame

    }

