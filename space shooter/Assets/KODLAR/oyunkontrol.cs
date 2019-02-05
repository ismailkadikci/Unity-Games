using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oyunkontrol : MonoBehaviour {


    public GameObject asteroid;
    public Vector3 randompos;
    public float başlangıçbekleme;
    public float oluşturmabekleme;
    public float döngübekleme;
    public Text text;
    public GameObject player;
    public Text text2;
    public Text text3;






    bool oyunbittikontrol =false ;

    bool yenidenbaşlakontrol = false;



    int score=0;

    

	void Start ()
    {

        text.text = "score" + score;
        text2.text = "";
        text3.text = "";



        StartCoroutine( oluştur());

		
	}

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.R) && yenidenbaşlakontrol==true)
        {
            oyunbittikontrol = false;
            yenidenbaşlakontrol = false;
            score = 0;
            player.active = true;

            player.transform.position = new Vector3(0, 0, -0.72f);


            Start();

        }
        
    }


    IEnumerator  oluştur ()
    {
        yield return new WaitForSeconds(başlangıçbekleme);
        while (true)
        {
            for (int i = 0; i < 10; i++)
            {
                Vector3 vec = new Vector3(Random.Range(-randompos.x, randompos.x), 0, randompos.z);

                Instantiate(asteroid, vec, Quaternion.identity);
                yield return new WaitForSeconds(oluşturmabekleme);

                if (oyunbittikontrol == true)
                {
                    break;

                }


            }
            yield return new WaitForSeconds(döngübekleme);


            if (oyunbittikontrol==true)
            {
                yenidenbaşlakontrol = true;

                break;

            }

        }
       
    }
    public void scorearttır(int gelenscore)
    {
        score += gelenscore;
        text.text ="score: "+ score;


    }
    public void oyunbitti()
    {
        Debug.Log("oyunbitti");
        oyunbittikontrol = true;
        player.active = false;
        text2.text = "GAME OVER";
        text3.text = "TO RESTRART PRESS 'R'";

        


    }
}
