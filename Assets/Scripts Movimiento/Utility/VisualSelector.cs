using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualSelector : MonoBehaviour
{
    [SerializeField] private GameObject marker;
    
    private string markerName;

    void Selected()
    {
        GameObject child = Instantiate(marker, transform);
        child.transform.localPosition = Vector3.up * 1;
        markerName = child.name;
    }

    void Deselected()
    {
        GameObject child = transform.Find(markerName).gameObject;
        if (child != null)
            Destroy(child);
    }

}
