using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temaslayokol : MonoBehaviour

{


    public GameObject patlama;

    public GameObject playerpatlama;

    GameObject oyunkontrol;
    oyunkontrol kontrol;


    private void Start()
    {
        oyunkontrol = GameObject.FindGameObjectWithTag("oyunkontrol");
        kontrol = oyunkontrol.GetComponent<oyunkontrol>();

    }


    private void OnTriggerEnter(Collider col)
    {

       

        if (col.tag != "sinir")
        {
            if (col.tag!="player")
            {
                Destroy(col.gameObject);


            }
            Destroy(gameObject);

            Instantiate(patlama, transform.position, transform.rotation);
            kontrol.scorearttır(10);
            
        }
        if (col.tag=="player")
        {
            
            Instantiate(playerpatlama, col.transform.position, col.transform.rotation);
            
            kontrol.oyunbitti();



        }
       
        

        


    }



}
