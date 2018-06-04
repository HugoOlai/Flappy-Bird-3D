using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pontos : MonoBehaviour {
    public Text P;
    public int i;
    public GameObject personagen;
    public AudioClip pontosAudio;

	// Use this for initialization
	void Start () {
        P.text = "Score";
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "pontos")
        {
            i++;
            P.text = "Score: " + i.ToString();
            som();
        }

        if(other.gameObject.tag == "canos")
        {
            personagen.SendMessage("FimGame");
        }
    }
    void som()
    {
        GetComponent<AudioSource>().PlayOneShot(pontosAudio);
    }
}
