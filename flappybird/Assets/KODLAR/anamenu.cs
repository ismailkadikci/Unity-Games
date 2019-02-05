using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class anamenu : MonoBehaviour {


    public Text puantext;
    public Text puan;



    void Start ()
    {
        int enyüksekskor = PlayerPrefs.GetInt("kayıt");
       
        int puangelen  = PlayerPrefs.GetInt("puankayıt");
        puantext.text = "En Yüksek Puan" + enyüksekskor;
        puan.text = "puan=" + puangelen;


    }
	
	void Update ()
    {
		
	}
   public void oyunagit()
    {
        SceneManager.LoadScene("level1");

    }
    public void oyundancık()
    {
        Application.Quit();

    }
}
