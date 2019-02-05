using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kursunkontrol : MonoBehaviour {


    düşmankontrol dusman;

    Rigidbody2D fizik;

	void Start ()
    {
        dusman = GameObject.FindGameObjectWithTag("dusman").GetComponent<düşmankontrol>();

        fizik = GetComponent<Rigidbody2D>();


        fizik.AddForce(dusman.getyon()*1000);
	}
	
	
}
