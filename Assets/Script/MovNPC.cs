using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovNPC : MonoBehaviour
{
    public GameObject marcador;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    void selected()
    {
        GameObject marker = Instantiate(marcador, transform);
        marker.transform.localPosition = Vector3.up * 1; // Change your position relative
    }

    void deselected()
    {
        GameObject marker = transform.GetChild(0).gameObject;

        Destroy(marker);
    }

}
