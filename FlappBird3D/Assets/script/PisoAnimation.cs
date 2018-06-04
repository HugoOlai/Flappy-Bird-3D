using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PisoAnimation : MonoBehaviour {
    public Material piso;
    public float velocidade;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float offset = Time.time * velocidade;
        piso.SetTextureOffset("_MainTex", new Vector2(offset, 0));
	}
}
