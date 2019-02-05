using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sınırlar : MonoBehaviour {

    private void OnTriggerExit(Collider col)
    {
        Destroy(col.gameObject);

    }
}
