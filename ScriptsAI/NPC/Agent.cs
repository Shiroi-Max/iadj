﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[AddComponentMenu("Steering/InteractiveObject/Agent")]
public class Agent : Bodi
{
    [Tooltip("Radio interior de la IA")]
    [SerializeField] protected float _interiorRadius = 1f;

    [Tooltip("Radio de llegada de la IA")]
    [SerializeField] protected float _arrivalRadius = 3f;

    [Tooltip("Ángulo interior de la IA")]
    [SerializeField] protected float _interiorAngle = 3.0f; // ángulo sexagesimal.

    [Tooltip("Ángulo exterior de la IA")]
    [SerializeField] protected float _exteriorAngle = 8.0f; // ángulo sexagesimal.


    // AÑADIR LAS PROPIEDADES PARA ESTOS ATRIBUTOS. SI LO VES NECESARIO.

    public float InteriorRadius
    {
        get { return _interiorRadius; }
        set { if (value < _arrivalRadius) _interiorRadius = value; }
    }

    public float ArrivalRadius
    {
        get { return _arrivalRadius; }
        set { if (value > _interiorRadius) _arrivalRadius = value; }
    }

    public float InteriorAngle
    {
        get { return _interiorAngle; }
        set { if (value < _exteriorAngle) _interiorAngle = value; }
    }

    public float ExteriorAngle
    {
        get { return _exteriorAngle; }
        set { if (value > _interiorAngle) _exteriorAngle = value; }
    }
    // AÑADIR MÉTODS FÁBRICA, SI LO VES NECESARIO.
    // En algún momento te puede interesar crear Agentes con tengan una posición
    // y unos radios: por ejemplo, crar un punto de llegada para un auténtico
    // Agente Inteligente. Este punto de llegada no tienen que ser inteligente,
    // solo tienen que ser "sensible" - si fuera necesario - a que lo tocan.
    // Planteate la posibilidad de crear aquí métodos fábrica (estáticos) para
    // crear esos agentes. Para ello crea un GameObject y usa:
    // .AddComponent<BoxCollider>();
    // .GetComponent<Collider>().isTrigger = true;
    // .AddComponent<Agent>();
    // Establece los valores del Bodi y radios/ángulos a los valores adecuados.
    // Esta es solo una de las muchas posiblidades para resolver este problema.



    // AÑADIR LO NECESARIO PARA MOSTRAR LA DEPURACIÓN. Te puede interesar los siguientes enlaces.
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _interiorRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _arrivalRadius);
    }
    // https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnDrawGizmos.html
    // https://docs.unity3d.com/ScriptReference/Debug.DrawLine.html
    // https://docs.unity3d.com/ScriptReference/Gizmos.DrawWireSphere.html
    // https://docs.unity3d.com/ScriptReference/Gizmos-color.html


}
