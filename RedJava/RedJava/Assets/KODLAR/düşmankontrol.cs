using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class düşmankontrol : MonoBehaviour
{


    GameObject[] gidileceknoktalar;
    Vector3 aradakimesafe;

    int aradakimesafesayacı = 0;

    bool ilerimigerimi = true;

    bool aradakimeafeyibirkereal = true;

    GameObject karakter;

    RaycastHit2D ray;

    public LayerMask layermask;

    public int hız=10;

    public Sprite ontaraf;
    public Sprite arkataraf;

    SpriteRenderer spriterenderer;
    public GameObject kursun;

    float ateszaman = 0;






    void Start()
    {
        gidileceknoktalar = new GameObject[transform.childCount];

        karakter = GameObject.FindGameObjectWithTag("Player");

        spriterenderer = GetComponent<SpriteRenderer>();



        for (int i = 0; i < gidileceknoktalar.Length; i++)
        {
            gidileceknoktalar[i] = transform.GetChild(0).gameObject;//0 olmak zorunda çünkü aldığımızı dışarı atıyoruz...
            gidileceknoktalar[i].transform.SetParent(transform.parent);


        }
    }

    void FixedUpdate()

    {
        benigördümü();

        if (ray.collider.tag=="Player")
        {
            hız = 10;
            spriterenderer.sprite = ontaraf;
            ateset();

        }
        else
        {
            hız = 5;

            spriterenderer.sprite = arkataraf;

        }


        noktalaragit();

    }

    void ateset()
    {
        ateszaman += Time.deltaTime;
        if (ateszaman>Random.Range(0.2f,1))
        {
            ateszaman = 0;
            Instantiate(kursun, transform.position, Quaternion.identity);
        }

    }

    void benigördümü()
    {
        Vector3 rayyonum = karakter.transform.position - transform.position;

        ray = Physics2D.Raycast(transform.position, rayyonum, 1000,layermask);

        Debug.DrawLine(transform.position, ray.point,Color.magenta);

    }
    void noktalaragit()
    {
        if (aradakimeafeyibirkereal)
        {
            aradakimesafe = (gidileceknoktalar[aradakimesafesayacı].transform.position - transform.position).normalized;



            aradakimeafeyibirkereal = false;
        }
        float mesafe = Vector3.Distance(transform.position, gidileceknoktalar[aradakimesafesayacı].transform.position);


        transform.position += aradakimesafe * Time.deltaTime * hız;

        if (mesafe < 0.5f)
        {
            aradakimeafeyibirkereal = true;


            if (aradakimesafesayacı == gidileceknoktalar.Length - 1)
            {
                ilerimigerimi = false;

            }
            else if (aradakimesafesayacı == 0)
            {
                ilerimigerimi = true;

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
    public Vector2 getyon()
    {
        return (karakter.transform.position - transform.position).normalized;

    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.GetChild(i).transform.position, 1);
        }
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.GetChild(i).transform.position, transform.GetChild(i + 1).transform.position);
        }
    }
#endif
}



#if UNITY_EDITOR
[CustomEditor(typeof(düşmankontrol))]
[System.Serializable]

class süşmankontroleditor : Editor
{
    public override void OnInspectorGUI()
    {
        düşmankontrol script = (düşmankontrol)target;  //targetı önce testereye benzetip sonra scripte eşitliyor böylelikle testere classını kullanabiliyoruz...
        EditorGUILayout.Space();


        if (GUILayout.Button("ÜRET", GUILayout.MinWidth(100), GUILayout.Width(100)))
        {
            GameObject yeniobjem = new GameObject();
            yeniobjem.transform.parent = script.transform;

            yeniobjem.transform.position = script.transform.position;

            yeniobjem.name = script.transform.childCount.ToString();//oluşan obje sayısını ada verir...

        }

        EditorGUILayout.Space();


        EditorGUILayout.PropertyField(serializedObject.FindProperty("layermask"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("ontaraf"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("arkataraf"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("kursun"));
        serializedObject.ApplyModifiedProperties();
        serializedObject.Update();

    }
   

}


#endif
