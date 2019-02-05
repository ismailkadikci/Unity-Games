using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerkontrol : MonoBehaviour {


    Rigidbody fizik;
    float horizontal = 0;
    float vertical = 0;
    Vector3 vec;

    public float karakterhız;

    float minX = -6.0f;
    float maxX = 6.0f;
    float minZ = -5.0f;
    float maxZ = 13.0f;

    public float egim ;
    float ateşzamanı = 0;

    public float gecensüre;
    public GameObject kursun;
    public Transform kursunnerdencıksın;

    AudioSource audio;





    void Start ()
    {    
               
        fizik = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();

	}


    void Update()
    {

        

        if (Input.GetButtonDown("Fire1")&& Time.time> ateşzamanı)
        {

            ateşzamanı = Time.time + gecensüre;

            Instantiate(kursun, kursunnerdencıksın.position, Quaternion.identity);
            audio.Play();


        }
    }


    void FixedUpdate ()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        vec = new Vector3(horizontal, 0, vertical);
        fizik.velocity = vec*karakterhız;

        fizik.position = new Vector3
            (
            Mathf.Clamp(fizik.position.x,minX,maxX),
            0.0f,
            Mathf.Clamp(fizik.position.z, minZ, maxZ)
            );

        fizik.rotation = Quaternion.Euler(0,0, fizik.velocity.x*-egim);


	}
}
