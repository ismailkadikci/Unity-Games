using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;


public class charactercontrol : MonoBehaviour {

    public Sprite[] beklemeanim;
    public Sprite[] zıplamaanim;
    public Sprite[] yürümeanim;

    SpriteRenderer spriterenderer;
    int beklemeanimsayac = 0;
    int yurumeanimsayac = 0;

  

    Rigidbody2D fizik;

    Vector3 vec;
    Vector3 kamerasonposition;
    Vector3 kamerailkposition;
    bool birkerezıpla = true;



    float horizontal = 0;
    float beklemeanimzaman = 0;
    float yurumeanimzaman = 0;

    float siyaharkaplansayacı = 0;
    float anamenuyedınzaman = 0;


    GameObject kamera;

    public Text cantext;
    public Image siyaharkaplan;

    int can = 10;

    int altınsayacı = 0;
    public Text TextAltın;



	void Start ()
    {
        siyaharkaplan.gameObject.SetActive(false);

        TextAltın.text = "30-" + altınsayacı;
        Time.timeScale = 1; //bölüm yavaşlamasın diye...
        spriterenderer = GetComponent<SpriteRenderer>();

        fizik = GetComponent<Rigidbody2D>();

        kamera = GameObject.FindGameObjectWithTag("MainCamera");
        kamerailkposition = kamera.transform.position - transform.position;

        cantext.text = "CAN   " + can;

        if (SceneManager.GetActiveScene().buildIndex> PlayerPrefs.GetInt("kacincilevel"))
        {
            PlayerPrefs.SetInt("kacincilevel", SceneManager.GetActiveScene().buildIndex);
        }

        


    }

    private void Update()
    {
        
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            if (birkerezıpla)
            {
                fizik.AddForce(new Vector2(0, 500));
                birkerezıpla = false;
                
            }

        }
        
    }

    void FixedUpdate()
    {

        karakterhareket();

        animasyon();
        if (can<=0)
        {
            Time.timeScale = 0.3f;
            cantext.enabled = false;
            siyaharkaplansayacı += 0.03f;
            siyaharkaplan.gameObject.SetActive(true);

            siyaharkaplan.color = new Color(0, 0, 0, siyaharkaplansayacı);

            anamenuyedınzaman += Time.deltaTime;
            if (anamenuyedınzaman>1)
            {
                SceneManager.LoadScene("AnaMenu");
            }
        }
       

	}

    private void LateUpdate()
    {
        kamerakontrol();

    }

    void karakterhareket()
    {
        horizontal =CrossPlatformInputManager.GetAxisRaw("Horizontal");
        vec =new Vector3(horizontal * 10, fizik.velocity.y, 0);
        fizik.velocity = vec;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        birkerezıpla = true;

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag=="kursun")
        {
            can--;
            cantext.text = "CAN  " + can;
        }
        if (col.gameObject.tag == "dusman")
        {
            can-=10;
            cantext.text = "CAN  " + can;
        }
        if (col.gameObject.tag == "testere")
        {
            can -= 10;
            cantext.text = "CAN  " + can;

        }

        if (col.gameObject.tag == "levelbitsin")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }


        if (col.gameObject.tag == "canver")
        {
            can += 10;

            cantext.text = "CAN  " + can;
                        col.GetComponent<BoxCollider2D>().enabled = false;

            col.GetComponent<canver>().enabled = true;


            Destroy(col.gameObject,3);
        }

        if (col.gameObject.tag=="altın")
        {

            altınsayacı++;
            TextAltın.text = "30-" + altınsayacı;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "su")
        {
            can = 0;
        }


    }
       
    void kamerakontrol()
    {
        kamerasonposition = transform.position + kamerailkposition;

        kamera.transform.position = Vector3.Lerp(kamera.transform.position, kamerasonposition, 0.1f);

    }

    void animasyon()
    {

        if (birkerezıpla)
        {
            if (horizontal == 0)
            {
                beklemeanimzaman += Time.deltaTime;
                if (beklemeanimzaman > 0.1f)
                {
                    spriterenderer.sprite = beklemeanim[beklemeanimsayac++];
                    if (beklemeanimsayac == beklemeanim.Length)
                    {
                        beklemeanimsayac = 0;

                    }
                    beklemeanimzaman = 0;

                }

            }
            else if (horizontal > 0)
            {

                yurumeanimzaman += Time.deltaTime;
                if (yurumeanimzaman > 0.1f)
                {
                    spriterenderer.sprite = yürümeanim[yurumeanimsayac++];
                    if (yurumeanimsayac == yürümeanim.Length)
                    {
                        yurumeanimsayac = 0;

                    }
                    yurumeanimzaman = 0;

                }

                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (horizontal < 0)
            {
                yurumeanimzaman += Time.deltaTime;
                if (yurumeanimzaman > 0.1f)
                {
                    spriterenderer.sprite = yürümeanim[yurumeanimsayac++];
                    if (yurumeanimsayac == yürümeanim.Length)
                    {
                        yurumeanimsayac = 0;

                    }
                    yurumeanimzaman = 0;

                }
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
          {
            if (fizik.velocity.y>0)
            {
                spriterenderer.sprite = zıplamaanim[0];

            }
            else
            {
                spriterenderer.sprite = zıplamaanim[1];
            }

            if (horizontal>0 )
            {
                transform.localScale = new Vector3(1, 1, 1);

            }
            else if (horizontal<0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        
    }

    


}
