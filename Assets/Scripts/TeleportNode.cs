using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TeleportNode : PathNode
{
    protected override Color GizmoColor => Color.magenta;

    public override Sequence MoveToNode(GameObject toMove)
    {
        Sequence ret = DOTween.Sequence();
        ret.AppendInterval(TimeToGetToNode);
        ret.AppendCallback(() => toMove.transform.SetPositionAndRotation(transform.position, transform.rotation));
        return ret;
    }
}
