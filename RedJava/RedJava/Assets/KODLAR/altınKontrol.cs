using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class altınKontrol : MonoBehaviour {

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
        if (zaman > 0.1f)
        {
            SpriteRenderer.sprite = AnimasyonKareleri[AnimasyonKareKacıncısı++];

            if (AnimasyonKareleri.Length == AnimasyonKareKacıncısı)
            {
                AnimasyonKareKacıncısı = 0;
            }
            zaman = 0;
            
        }

    }
}
