using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anacemberkod : MonoBehaviour {
    public GameObject küçükcember;

    GameObject oyunyöneticisi;

	
	void Start ()
    {
        oyunyöneticisi = GameObject.FindGameObjectWithTag("oyunyöneticisitag");

	}
	
	
	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            küçükcemberoluştur();

        }
	}
    void küçükcemberoluştur()
    {
        Instantiate(küçükcember, transform.position, transform.rotation);
        oyunyöneticisi.GetComponent<oyunyöneticisi>().kucukcemberlerdetextgosterme();

    }
}

