using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyunkontrol : MonoBehaviour {

    public GameObject gokyuzu1;
    public GameObject gokyuzu2;

    Rigidbody2D fizik1;
    Rigidbody2D fizik2;

    float uzunluk = 0;

    public float arkaplanhız = -1.5f;


    public GameObject engel;
    public int kacadetengel =5;
    GameObject[] engeller;


    float degisimzaman = 0;
    int sayac=0;

    bool oyunbitiveriyo = true;


    





    void Start ()
    {
        fizik1 = gokyuzu1.GetComponent<Rigidbody2D>();
        fizik2 = gokyuzu2.GetComponent<Rigidbody2D>();

        fizik1.velocity = new Vector2(arkaplanhız, 0);
        fizik2.velocity = new Vector2(arkaplanhız, 0);

        uzunluk = gokyuzu1.GetComponent<BoxCollider2D>().size.x;




        engeller = new GameObject[kacadetengel];
        for (int i = 0; i < engeller.Length; i++)
        {
            engeller[i] = Instantiate(engel, new Vector2(-20, -20), Quaternion.identity);

            Rigidbody2D fizikengel = engeller[i].AddComponent<Rigidbody2D>();
            fizikengel.gravityScale = 0;
            fizikengel.velocity = new Vector2(arkaplanhız,0);

        }
    }
	
	void Update ()
    {

        if (oyunbitiveriyo )
        {
            if (gokyuzu1.transform.position.x <= -uzunluk)
            {
                gokyuzu1.transform.position += new Vector3(uzunluk * 2, 0);

            }
            if (gokyuzu2.transform.position.x <= -uzunluk)
            {
                gokyuzu2.transform.position += new Vector3(uzunluk * 2, 0);

            }
            degisimzaman += Time.deltaTime;
            if (degisimzaman > 2f)
            {
                degisimzaman = 0;
                float yeksenim = Random.Range(1.10f, -0.5f);

                engeller[sayac].transform.position = new Vector2(11.5f, yeksenim);
                sayac++;

                if (sayac >= engeller.Length)
                {
                    sayac = 0;

                }

            }


        }
        else
        {
                
        }

    }

    public void oyunbitti()
    {
        for (int i = 0; i < engeller.Length; i++)
        {
            engeller[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;


            fizik1.velocity = Vector2.zero;
            fizik2.velocity = Vector2.zero;




        }

        oyunbitiveriyo = false;

      //  Destroy(this);  bu kod engellerin  tekrarlanmasını engeller ama ilerde sıkıntı...

    }
}
