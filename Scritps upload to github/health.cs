using UnityEngine;
using System.Collections;

public class health : MonoBehaviour
{
    private Player user;

    // Use this for initialization
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
        user = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

    // Update is called once per frame


    void OnTriggerEnter2D(Collider2D col)

    {

        if (col.CompareTag("Player"))

        {

            user.maxhealth += 400;
            user.currenthealth += 400;
            Destroy(gameObject);

        }
    }
}