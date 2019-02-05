using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class anamenukontrol : MonoBehaviour {

    GameObject level1, level2, level3;
    GameObject kilit1, kilit2, kilit3;
    GameObject Leveller;
    GameObject Kilitler;


	void Start ()
    {
        //PlayerPrefs.DeleteAll();

        Kilitler = GameObject.Find("Kilitler");


        Leveller = GameObject.Find("Leveller");
        for (int i = 0; i < Leveller.transform.childCount; i++)
        {
            Leveller.transform.GetChild(i).gameObject.SetActive(false);

        }

        for (int i = 0; i < Kilitler.transform.childCount; i++)
        {
            Kilitler.transform.GetChild(i).gameObject.SetActive(false);

        }


        for (int i = 0; i < PlayerPrefs.GetInt("kacincilevel"); i++)
        {
            Leveller.transform.GetChild(i).GetComponent<Button>().interactable = true;
        }
        
    }

    public void butonsec(int gelenButon)
    {
        if (gelenButon ==1)
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("kacincilevel"));//kaldığımız yerden devam etmesi için...

        }
        else if (gelenButon ==2)
        {
            for (int i = 0; i < Leveller.transform.childCount; i++)
            {
                Leveller.transform.GetChild(i).gameObject.SetActive(true);

                Kilitler.transform.GetChild(i).gameObject.SetActive(true);
            }




            for (int i = 0; i < PlayerPrefs.GetInt("kacincilevel"); i++)
            {
                Kilitler.transform.GetChild(i).gameObject.SetActive(false);


            }
        }
        else if (gelenButon ==3)
        {
            Application.Quit();

        }

    }
    public void LevellerButon(int GelenLevel)
    {
        SceneManager.LoadScene(GelenLevel);

    }

}
