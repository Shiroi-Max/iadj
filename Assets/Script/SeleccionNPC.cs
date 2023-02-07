using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionNPC : MonoBehaviour
{
    public ArrayList selectedUnits; 

    // Start is called before the first frame update
    void Start()
    {
        selectedUnits = new ArrayList();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider != null && hitInfo.collider.CompareTag("NPC"))
                {
                    GameObject npc = hitInfo.transform.gameObject;
                    if(!Input.GetKey(KeyCode.LeftShift))
                    {
                        deseleccionarTodos();
                        npc.SendMessage("selected");
                        selectedUnits.Add(npc);
                    }else if(!selectedUnits.Contains(npc)){
                        npc.SendMessage("selected");
                        selectedUnits.Add(npc);
                    }
                }
            }

            if( hitInfo.collider != null && hitInfo.collider.CompareTag("Terraiin"))

        }

            
    }

    void deseleccionarTodos()
    {
        foreach (GameObject npc in selectedUnits)
        {
            npc.SendMessage("deselected");
        }
        selectedUnits.Clear();
    }
}
