using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefense : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator anim;
    private bool def = false;
    private Player player;



    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        player = gameObject.GetComponentInParent<Player>();
        
    }
    void Start()
    {
        def = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.alive == true)

        {
            if (Input.GetKey("q") || (Input.GetButton("Fire8"))) //RT in Xbox Controller(not working) or q Key on Keyboard (GetKey is when its pressed and hold same as getbutton )
            {
                def = true;
                player.defending = true;
                anim.SetBool("Defending", def);
                player.gethit = false;
                player.speed = 0;

            }
            else            
            {
                
                def = false;
                player.defending = false;
                player.speed = 42f;

            }
        
        }
    }
}
