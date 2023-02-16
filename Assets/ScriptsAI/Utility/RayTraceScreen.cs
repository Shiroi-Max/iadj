using UnityEngine;

public class RayTraceScreen
{
    // private GameObject firstThing = null;
    // private GameObject secondThing = null;
    // private bool firstTime = true;

    // MeshRenderer m_Renderer = null;
    // Color m_OriginalColor = Color.green;

    public static void draw(Ray ray, RaycastHit hit)
    {
        Debug.DrawLine(ray.origin, hit.point, Color.green);
        // Debug.DrawLine(hit.point, hit.point + 20 * hit.normal, Color.blue);
    }

    void changeColor(RaycastHit hit)
    {
        // string str = hit.transform.gameObject.name;
        // if (firstTime && !(str.Equals("Plane") || str.Equals("Quad")))
        // {
        //     firstThing = hit.transform.gameObject;
        //     m_Renderer = firstThing.GetComponent<MeshRenderer>();
        //     m_OriginalColor = m_Renderer.material.color;
        //     m_Renderer.material.color = Color.white;
        //     firstTime = false;
        //     return;
        // }
        // if (firstThing == null) return;

        // secondThing = hit.transform.gameObject;
        // if (firstThing == secondThing) return;

        // m_Renderer.material.color = m_OriginalColor;

        // firstTime = true;
    }

}