using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class path : MonoBehaviour
{
    public Color line;
    private List<Transform> nodes = new List<Transform>();
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = line;
        Transform[] pathT = GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i = 0; i < pathT.Length; i++)
        {
            if (pathT[i] != transform)
            {
                nodes.Add(pathT[i]);
            }
        }
        for (int i = 0; i < nodes.Count; i++)
        {
            Vector3 CNodes = nodes[i].position;
            Vector3 PNodes = Vector3.zero;
            if (i > 0)
            {
                PNodes = nodes[i - 1].position;
            }
            else if (i == 0 && nodes.Count > 1)
            {
                PNodes = nodes[nodes.Count - 1].position;
            }
            Gizmos.DrawLine(PNodes, CNodes);
            Gizmos.DrawWireSphere(CNodes, 0.3f);
        }
    }
}
