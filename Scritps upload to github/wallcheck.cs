using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallcheck : MonoBehaviour
{
    private Player player;
    
    // Start is called before the first frame update

        //This script will check fo the tag WALLS if its true on collider then it will be able to wallslide
        //This should be put into a collider in order to work 
    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();
    }


  

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.isTrigger != true && col.CompareTag("Walls"))
        {

            player.wallCheck = true;
        }

       // player.wallCheck = false;
           else
           {
               player.wallCheck = false;
          }
    }

    void OnTriggerExit2D(Collider2D col)
    {

        player.wallCheck = false;
    }
    // Update is called once per frame

}
