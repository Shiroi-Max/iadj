using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionNPC : MonoBehaviour
{
    public ArrayList selectedUnits;
    public Agent npcVirtual;

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

            if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider != null)
            {
                if (hitInfo.collider.CompareTag("NPC"))
                {
                    GameObject npc = hitInfo.transform.gameObject;
                    if (!Input.GetKey(KeyCode.LeftShift))
                    {
                        deseleccionarTodos();
                        npc.SendMessage("Selected");
                        selectedUnits.Add(npc);
                    }
                    else if (!selectedUnits.Contains(npc))
                    {
                        npc.SendMessage("Selected");
                        selectedUnits.Add(npc);
                    }
                }
                else
                if (hitInfo.collider.CompareTag("Terrain") && selectedUnits.Count > 0)
                {
                    Agent npc = Instantiate(npcVirtual);
                    Vector3 v = hitInfo.point;
                    v.y = 0;
                    npc.transform.localPosition = v;

                    foreach (GameObject unit in selectedUnits)
                        unit.SendMessage("NewTarget", npc);
                }
            }
        }

        void deseleccionarTodos()
        {
            foreach (GameObject unit in selectedUnits)
                unit.SendMessage("Deselected");
            selectedUnits.Clear();
        }
    }
}