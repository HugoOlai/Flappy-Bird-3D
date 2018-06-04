using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjs : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -3f);
        Invoke("destroi", 5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void destroi()
    {
        Destroy(this.gameObject);
    }
}
