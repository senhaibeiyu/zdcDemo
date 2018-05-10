using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMoveCamera : MonoBehaviour {
	public float speed = 10;
	public float endY = 49;
    
	void Update () {
		if (transform.position.y > endY) {
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}
	}
}
