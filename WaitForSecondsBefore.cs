using UnityEngine;
using System.Collections;

public class WaitForSecondsBefore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(BeforeDie());
	}

	IEnumerator BeforeDie() {
		print(Time.time);
		yield return new WaitForSeconds(40);
		print(Time.time);
	}

}
