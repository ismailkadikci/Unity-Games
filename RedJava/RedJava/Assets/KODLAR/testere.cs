using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class testere : MonoBehaviour {


    GameObject []gidileceknoktalar;
    Vector3 aradakimesafe;

    int aradakimesafesayacı = 0;

    bool ilerimigerimi = true;

    bool aradakimeafeyibirkereal = true;

	void Start ()
    {
        gidileceknoktalar = new GameObject[transform.childCount];

        for (int i = 0; i < gidileceknoktalar.Length; i++)
        {
            gidileceknoktalar[i] = transform.GetChild(0).gameObject;//0 olmak zorunda çünkü aldığımızı dışarı atıyoruz...
            gidileceknoktalar[i].transform.SetParent(transform.parent);


        }
	}
	
	void FixedUpdate ()

    {
        transform.Rotate(0, 0,5);
        noktalaragit();

	}
    void noktalaragit()
    {
        if (aradakimeafeyibirkereal)
        {
            aradakimesafe = (gidileceknoktalar[aradakimesafesayacı].transform.position - transform.position).normalized;

          

            aradakimeafeyibirkereal = false;
        }
        float mesafe = Vector3.Distance(transform.position, gidileceknoktalar[aradakimesafesayacı].transform.position);


        transform.position += aradakimesafe*Time.deltaTime*10;

        if (mesafe<0.5f)
        {
            aradakimeafeyibirkereal = true;

           
            if (aradakimesafesayacı == gidileceknoktalar.Length-1)
            {
                ilerimigerimi = false;

            }
            else if (aradakimesafesayacı==0)
            {
                ilerimigerimi =true;

            }
            if (ilerimigerimi)
            {

                aradakimesafesayacı++;

            }
            else
            {
                aradakimesafesayacı--;

            }

        }



    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.GetChild(i).transform.position, 1);
        }
        for (int i = 0; i < transform.childCount-1; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.GetChild(i).transform.position,transform.GetChild(i+1).transform.position);
        }
    }
#endif
}



#if UNITY_EDITOR
[CustomEditor(typeof(testere))]
[System.Serializable]

class testereeditor : Editor
{
    public override void OnInspectorGUI()
    {
        testere script = (testere)target;  //targetı önce testereye benzetip sonra scripte eşitliyor böylelikle testere classını kullanabiliyoruz...


        if (GUILayout.Button("ÜRET",GUILayout.MinWidth(100),GUILayout.Width(100)))
        {
            GameObject yeniobjem = new GameObject();
            yeniobjem.transform.parent = script.transform;

            yeniobjem.transform.position = script.transform.position;

            yeniobjem.name = script.transform.childCount.ToString();//oluşan obje sayısını ada verir...

        }
    }

}


#endif
