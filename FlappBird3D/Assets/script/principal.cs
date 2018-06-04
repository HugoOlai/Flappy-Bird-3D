using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class principal : MonoBehaviour {
    public GameObject cerca;
    public GameObject nuvem;
    public GameObject cano;
    public GameObject pedra;
    public GameObject mato;

    public Text inicio;
    bool comeca;
    bool fim = false;
    public GameObject Jogador;
    public GameObject P;

    public AudioClip voa;
    public AudioClip fimGame;

    // Use this for initialization
    void Start() {
        inicio.text = "TOQUE PARA INICIAR";
    }

    // Update is called once per frame
    void Update() {

        if(!fim)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (!comeca)
                {
                    comeca = true;
                    InvokeRepeating("InsCerca", 1, 0.2f);
                    InvokeRepeating("CriaObj", 2, 1f);
                    inicio.text = "";
                }
                movimentaJogador();
            }
            Jogador.transform.rotation = Quaternion.Euler(Jogador.GetComponent<Rigidbody>().velocity.y * -10, 0, 0);

        }

    }

    void InsCerca()
    {
        Instantiate(cerca);
    }

    void CriaObj()
    {
        int i = Random.Range(1, 5);
        float x = Random.Range(1.16f, -1.16f);
        float y = Random.Range(0f, -0.82f);
        float Yn = Random.Range(1.72f, 0.55f);
        float z = Random.Range(1.16f, -1.16f);

        transform.position=new Vector3(x, 0, 0);
        GameObject itensC = new GameObject();
        switch (i)
        {
            case 1: itensC = Instantiate(cano); itensC.transform.position = new Vector3(0.45f, y, itensC.transform.position.z); break;
            case 2: itensC = Instantiate(pedra); itensC.transform.position = new Vector3(x, 0, itensC.transform.position.z); break;
            case 3: itensC = Instantiate(mato); itensC.transform.position = new Vector3(x, 0, itensC.transform.position.z);  break;
            case 4: itensC = Instantiate(nuvem); itensC.transform.position = new Vector3(x, Yn, itensC.transform.position.z); break;
        }
    }

    void movimentaJogador()
    {
        GameObject novaPar= Instantiate(P);
        novaPar.transform.position = Jogador.transform.position;
        Destroy(novaPar, 2);
        GetComponent<AudioSource>().PlayOneShot(voa);
        Jogador.GetComponent<Rigidbody>().useGravity = true;
        Jogador.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 3.0f, 0.0f);
        Jogador.transform.rotation = Quaternion.Euler(Jogador.GetComponent<Rigidbody>().velocity.y*10, 0, 0);
    }


    void FimGame()
    {
        fim = true;
        GetComponent<AudioSource>().PlayOneShot(fimGame);
        CancelInvoke("InsCerca");
        CancelInvoke("CriaObj"); 
        Jogador.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 5.0f, -5.0f);
        Jogador.transform.rotation = Quaternion.Euler(Jogador.GetComponent<Rigidbody>().velocity.y * 15, 0, 0);
        Invoke("carregaCena", 2);
    }

    void carregaCena()
    {
        Application.LoadLevel("SampleScene");
    }

}
