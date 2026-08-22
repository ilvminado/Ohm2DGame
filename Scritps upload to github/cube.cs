using UnityEngine;
using System.Collections;

public class cube : MonoBehaviour {
	public float moveSpeed;
	public float h;
	public float j;
	// Use this for initialization
	void Start () {
		moveSpeed = 0.1f;
	
	}
	
	// Update is called once per frame
	void Update () {
		h = Input.GetAxis ("Horizontal");
		j = Input.GetAxis ("Vertical");

			transform.Translate (moveSpeed * h ,0f ,  0f );
			transform.Translate (0f , 0f , moveSpeed * j );

		}

	}

