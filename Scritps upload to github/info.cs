using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class info : MonoBehaviour
{

    public string information = "Important Information Here";
    private Player user;
    // Start is called before the first frame update
    void Start()
    {
        user = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            user.information = information;
        }

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
