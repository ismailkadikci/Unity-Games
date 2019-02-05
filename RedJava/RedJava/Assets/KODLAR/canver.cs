using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canver : MonoBehaviour {

    public Sprite[] AnimasyonKareleri;
   SpriteRenderer SpriteRenderer;
    float zaman = 0;
    int AnimasyonKareKacıncısı;


	void Start ()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();

	}
	
	void Update ()
    {
        zaman += Time.deltaTime;
        if (zaman>0.5f)
        {
            SpriteRenderer.sprite = AnimasyonKareleri[AnimasyonKareKacıncısı++];

            if (AnimasyonKareleri.Length==AnimasyonKareKacıncısı)
            {
                AnimasyonKareKacıncısı = AnimasyonKareleri.Length-1;
            }
            zaman = 0;


        }
	}
}
