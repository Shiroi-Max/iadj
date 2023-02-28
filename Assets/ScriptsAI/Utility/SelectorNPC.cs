using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorNPC : MonoBehaviour
{
    public List<GameObject> selectedUnits;
    public FormationManager formationManager;
    public Agent npcVirtual;

    void Start()
    {
        selectedUnits = new List<GameObject>();
    }

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
                    {
                        if (unit.GetComponent<Brain>().status == Status.Formation)
                            formationManager.BreakFormation(unit.GetComponent<AgentNPC>());
                        unit.SendMessage("NewTarget", npc);
                    }
                }
            }
        }
        else if (Input.GetKeyUp("f") && selectedUnits.Count > 1) // Tratar de modificar el proceso
        {
            List<AgentNPC> npcs = new List<AgentNPC>();
            for (int i = 0; i < selectedUnits.Count; i++)
                npcs.Add(selectedUnits[i].GetComponent<AgentNPC>());
            formationManager.StartFormation(npcs);
        }

        void deseleccionarTodos()
        {
            foreach (GameObject unit in selectedUnits)
                unit.SendMessage("Deselected");
            selectedUnits.Clear();
        }
    }
}