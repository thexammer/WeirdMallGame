using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SimpleMoveNode : PathNode
{
    protected override Color GizmoColor => Color.blue;

    public override Sequence MoveToNode(GameObject toMove)
    {
        Sequence ret = DOTween.Sequence();
        ret.Append(toMove.transform.DOMove(transform.position, TimeToGetToNode));
        ret.Insert(0, toMove.transform.DORotateQuaternion(transform.rotation, TimeToGetToNode));
        return ret;
    }
}
