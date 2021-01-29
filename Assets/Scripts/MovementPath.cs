using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MovementPath : MonoBehaviour
{
    public GameObject ObjectToMove;

    private List<PathNode> nodes = new List<PathNode>();

    private int currentNode = 0;

    // Set up nodes, make sure they are invisible
    private void Awake()
    {
        // Convention: all nodes are on children of the gameobject this is attached to
        // Any children that do not have a PathNode component are disabled and ignored
        foreach (Transform child in transform)
        {
            PathNode node = child.gameObject.GetComponent<PathNode>();
            if (node != null)
            {
                nodes.Add(node);
                MeshRenderer render = child.gameObject.GetComponent<MeshRenderer>();
                if (render != null) { render.enabled = false; }
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    private void Start()
    {
        ObjectToMove.transform.SetPositionAndRotation(nodes[0].transform.position, nodes[0].transform.rotation);
        MoveToNext();
    }

    private void MoveToNext()
    {
        currentNode = (currentNode + 1) % nodes.Count;
        nodes[currentNode].MoveToNode(ObjectToMove).AppendCallback(MoveToNext);
    }
}
