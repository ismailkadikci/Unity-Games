using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class oyunyöneticisi : MonoBehaviour {

    GameObject dönencember;
    GameObject anacember;
    public Animator animator;

    public Text dönencemberlevel1;
    public Text bir;
    public Text iki;
    public Text üc;
    public int kactanekucukcemberolsun;

    bool kontrol = true;




    void Start () {
        PlayerPrefs.SetInt("kayit",int.Parse(SceneManager.GetActiveScene().name));

        dönencember = GameObject.FindGameObjectWithTag("dönençember");
        anacember = GameObject.FindGameObjectWithTag("anacembertag");
        dönencemberlevel1.text = SceneManager.GetActiveScene().name;

        if (kactanekucukcemberolsun<2)
        {
            bir.text = kactanekucukcemberolsun+"";
        }
        else if (kactanekucukcemberolsun<3)
        {
            bir.text = (kactanekucukcemberolsun) + "";
            iki.text = (kactanekucukcemberolsun - 1) + "";

        }
        else
        {
            bir.text = (kactanekucukcemberolsun) + "";
            iki.text = (kactanekucukcemberolsun - 1) + "";
            üc.text = (kactanekucukcemberolsun - 2) + "";

        }


    }
    public void kucukcemberlerdetextgosterme()
    {
        kactanekucukcemberolsun -= 1;
        if (kactanekucukcemberolsun < 2)
        {
            bir.text = kactanekucukcemberolsun + "";
            iki.text = "";
            üc.text = "";
             
        }
        else if (kactanekucukcemberolsun < 3)
        {
            bir.text = (kactanekucukcemberolsun) + "";
            iki.text = (kactanekucukcemberolsun - 1) + "";
            üc.text = "";


        }
        else
        {
            bir.text = (kactanekucukcemberolsun) + "";
            iki.text = (kactanekucukcemberolsun - 1) + "";
            üc.text = (kactanekucukcemberolsun - 2) + "";

        }
        if (kactanekucukcemberolsun==0)
        {
            StartCoroutine(yenilevel());


        }

    }
    IEnumerator yenilevel()
    {
        dönencember.GetComponent<döndürme>().enabled = false;
        anacember.GetComponent<anacemberkod>().enabled = false;

        yield return new WaitForSeconds(0.5f);
        if (kontrol==true)
        {
            animator.SetTrigger("yenilevel");

            yield return new WaitForSeconds(1);

            int a = int.Parse(SceneManager.GetActiveScene().name);
            Debug.Log(a + 1);
            SceneManager.LoadScene((a + 1));
        }
        
    }

    public void oyunbitti()
    {
        StartCoroutine(çağrılanmetot());

    }

    IEnumerator çağrılanmetot()
    {
        dönencember.GetComponent<döndürme>().enabled = false;
        anacember.GetComponent<anacemberkod>().enabled = false;
        animator.SetTrigger("OYUNBİTTİ");
        kontrol = false;


        yield return new WaitForSeconds(5);

        SceneManager.LoadScene("anamenü");


    }
}
