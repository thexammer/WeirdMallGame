using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class WaitNode : PathNode
{
    protected override Color GizmoColor => Color.black;

    public override Sequence MoveToNode(GameObject toMove)
    {
        Sequence ret = DOTween.Sequence();
        ret.AppendInterval(TimeToGetToNode);
        return ret;
    }
}
