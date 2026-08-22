using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damg = 5;
    public float distance = 0f;
    public float maxdistance = 100f;

    Player enemy;
    void Start()
    {
        rb.velocity = transform.right * speed;


    }

    void OnTriggerEnter2D(Collider2D col)
    {

         enemy = col.GetComponent<Player>();

       

        if (col.isTrigger != true && col.CompareTag("Player"))
        {
           // col.SendMessageUpwards("Damage", damg);
            enemy.Damage(damg);
            //enemy.Damage(100);
            Destroy(gameObject);
            Debug.Log(col.name);
        }

        if (col.CompareTag("Walls") || (col.CompareTag("roca")))
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {




        if (distance > 30f)
        {

            damg = 50;
        }
        if (distance == maxdistance)
        {
            Destroy(gameObject);
        }
        distance += 1;
        if (distance < 30)
        {
            damg = 100;
        }
    }
}