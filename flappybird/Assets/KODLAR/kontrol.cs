using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class kontrol : MonoBehaviour {
    public Sprite []kussprite;
    SpriteRenderer spriterenderer;
    bool ilerigerikontrol = true;
    int kussayac = 0;
    float kusanimasyonzaman;
    Rigidbody2D fizik;

    int puan = 0;

    public Text puantext;

    bool oyunbitti = true;

    oyunkontrol oyunkontrol;

    //AudioSource ses;
    ///public AudioClip çarpma;
    // public AudioClip puansesi;
    // public AudioClip kanatsesi;

    AudioSource []sesler;
    int enyüksekpuan=0;

          



    void Start ()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
        fizik = GetComponent<Rigidbody2D>();

        oyunkontrol = GameObject.FindGameObjectWithTag("oyunkontrol").GetComponent<oyunkontrol>();

        //ses = GetComponent<AudioSource>();
        sesler = GetComponents<AudioSource>();

        enyüksekpuan = PlayerPrefs.GetInt("kayıt");

    }

    void Update ()
    {
        kusanimasyonzaman += Time.deltaTime;
        ucankus();
        if (Input.GetMouseButtonDown(0)&& oyunbitti)
        {
            fizik.velocity = new Vector2(0, 0);

            fizik.AddForce(new Vector2(0,200));
            //ses.clip = kanatsesi;
            // ses.Play();
            sesler[0].Play();

            
        }
        if (fizik.velocity.y>0)
        {
            transform.eulerAngles = new Vector3(0, 0, 45);

        }
        if (fizik.velocity.y<0)
        {
            transform.eulerAngles = new Vector3(0, 0, -45);

        }


       
	}
    void ucankus()
    {
        if (kusanimasyonzaman > 1)
        {
            kusanimasyonzaman = 0;
            if (ilerigerikontrol)
            {
                spriterenderer.sprite = kussprite[kussayac];
                kussayac++;
                if (kussayac == kussprite.Length)
                {
                    kussayac--;

                    ilerigerikontrol = false;

                }
            }
            else
            {
                kussayac--;
                spriterenderer.sprite = kussprite[kussayac];
                if (kussayac == 0)
                {
                    kussayac++;

                    ilerigerikontrol = true;

                }
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag=="puan")
        {
            puan++;
            puantext.text = "puan=" + puan;
            //ses.clip = puansesi;
            // ses.Play();
            sesler[1].Play();



        }

        if (col.gameObject.tag=="engel")
        {
            oyunbitti = false;

            oyunkontrol.oyunbitti();
            // ses.clip = çarpma;
            // ses.Play();
            sesler[2].Play();
            GetComponent<CircleCollider2D>().enabled = false;
            if (puan>enyüksekpuan)
            {
                enyüksekpuan = puan;

                PlayerPrefs.SetInt("kayıt", enyüksekpuan);
            }
            Invoke("anamenüyedön", 2);





        }
    }
    void anamenüyedön()
    {
        PlayerPrefs.SetInt("puankayıt", puan);
        SceneManager.LoadScene("AnaMenu");

    }
}
