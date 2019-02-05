using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menukontrol : MonoBehaviour {

    public void Start()
    {
      // PlayerPrefs.DeleteAll();

    }
    public void oyunagit()
    {
        int kayıtlılevel = PlayerPrefs.GetInt("kayit");
        if (kayıtlılevel==0)
        {
            SceneManager.LoadScene(kayıtlılevel+1);

        }
        else
        {
            SceneManager.LoadScene(kayıtlılevel);

        }

        

    }
    public void cik()
    {
        Application.Quit();

    }
}
