using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public abstract class PathNode : MonoBehaviour
{
    /// <summary>
    /// The amount of time it takes the object to get to the transform position and rotation upon movement starting.
    /// </summary>
    public float TimeToGetToNode;

    protected abstract Color GizmoColor { get; }

    /// <summary>
    /// Moves the given GameObject to the point defined by this node.
    /// </summary>
    /// <param name="toMove"></param>
    /// <returns>The Sequence controlling the movement of the GameObject.</returns>
    public abstract Sequence MoveToNode(GameObject toMove);
    private void OnDrawGizmos()
    {
        Gizmos.color = GizmoColor;
        Gizmos.DrawSphere(transform.position, 0.5f);
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 2);
        Gizmos.DrawLine(transform.position, transform.position + transform.up);
    }
}
