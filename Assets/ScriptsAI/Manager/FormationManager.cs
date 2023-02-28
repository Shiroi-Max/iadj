using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FormationManager : MonoBehaviour
{
    private List<List<AgentNPC>> inFormation;

    public void Start()
    {
        inFormation = new List<List<AgentNPC>>();
    }

    public void StartFormation(List<AgentNPC> npcs)
    {
        List<int> indexList = new List<int>(); // Tratar de mejorar este proceso
        foreach (List<AgentNPC> list in inFormation)
            foreach (AgentNPC npc in list)
                if (npcs.Contains(npc))
                    indexList.Add(inFormation.IndexOf(list));

        indexList.Sort();
        indexList.Reverse();
        indexList = indexList.Distinct().ToList();
        foreach (int index in indexList)
        {
            foreach (AgentNPC npc in inFormation[index])
                npc.GetComponent<Brain>().BreakFormation();
            inFormation.RemoveAt(index);
        }

        AgentNPC leader = npcs[0];
        FormationPattern pattern = leader.GetComponent<Formation>().Pattern;

        if (!pattern.SupportSlots(npcs.Count)) return;

        for (int i = 1; i < npcs.Count; i++)
            if (!npcs[i].GetComponent<Formation>().Pattern.NamePattern.Equals(pattern.NamePattern))
                return;

        for (int i = 0; i < npcs.Count; i++)
            npcs[i].GetComponent<Brain>().StartFormation(leader, i);

        inFormation.Add(npcs);
    }

    public void BreakFormation(AgentNPC npc)
    {
        int index = -1;
        foreach (List<AgentNPC> list in inFormation)
            if (list.Contains(npc))
            {
                index = inFormation.IndexOf(list);
                foreach (AgentNPC n in list)
                    n.GetComponent<Brain>().BreakFormation();
            }
        if (index > -1)
            inFormation.RemoveAt(index);
    }
}
