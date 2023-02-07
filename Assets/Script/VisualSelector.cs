using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualSelector : MonoBehaviour
{
    public GameObject marcador;

    void Selected()
    {
        GameObject marker = Instantiate(marcador, transform);
        marker.transform.localPosition = Vector3.up * 1;
    }

    void Deselected()
    {
        GameObject marker = transform.GetChild(0).gameObject;

        Destroy(marker);
    }

}
