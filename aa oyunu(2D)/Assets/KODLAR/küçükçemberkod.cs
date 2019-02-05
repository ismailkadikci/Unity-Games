using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class küçükçemberkod : MonoBehaviour {

    Rigidbody2D fizik;
    public float hız;
    bool hareketkontrol = false;
    GameObject oyunyöneticisi;
    



	void Start ()
    {
        fizik = GetComponent<Rigidbody2D>();
        oyunyöneticisi = GameObject.FindGameObjectWithTag("oyunyöneticisitag");
        

	}
	
	void FixedUpdate ()
    {
        if (!hareketkontrol )
        {
            fizik.MovePosition(fizik.position + Vector2.up * hız * Time.deltaTime);

        }

	}
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag=="dönençember")
        {
            transform.SetParent(col.transform);
            hareketkontrol = true;


        }
        if (col.tag=="kücükcembertag")
        {
            oyunyöneticisi.GetComponent<oyunyöneticisi>().oyunbitti();

        }
    }
}
