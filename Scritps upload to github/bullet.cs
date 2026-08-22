using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damg = 100;
    public float distance = 0f;
    public float maxdistance = 20f;
    void Start()
    {
        rb.velocity = transform.right * speed;
        
    }

     void OnTriggerEnter2D(Collider2D col)
    {

        enemyfollows enemy = col.GetComponent<enemyfollows>();
        if (col.isTrigger != true && col.CompareTag("Enemy"))
            {
            col.SendMessageUpwards("Damage", damg);
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
        if (distance == maxdistance) {
            Destroy(gameObject);
        }
        distance += 1;
    }
}
