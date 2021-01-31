using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public enum Axis
{
    x,
    y,
    z
}

public class SpinningNode : PathNode
{
    public Axis SpinAxis = Axis.y;

    public int NumberOfSpins = 50;
    protected override Color GizmoColor => Color.green;

    public override Sequence MoveToNode(GameObject toMove)
    {
        Sequence ret = DOTween.Sequence();
        Vector3 orgiScale = toMove.transform.localScale;
        ret.Append(toMove.transform.DOScale(Vector3.zero, TimeToGetToNode / 2));
        ret.AppendCallback(() => toMove.transform.position = transform.position);
        ret.Append(toMove.transform.DOScale(orgiScale, TimeToGetToNode / 2));
        ret.Insert(0, MakeItSpin(toMove));
        return ret;
    }

    private Sequence MakeItSpin(GameObject toMove)
    {
        Sequence ret = DOTween.Sequence();
        for (int i = 0; i < NumberOfSpins; ++i)
        {
            ret.Append(toMove.transform.DORotate(Vector3.zero, TimeToGetToNode / NumberOfSpins / 2, RotateMode.FastBeyond360));
            Vector3 rot = new Vector3(180 * (SpinAxis == Axis.x ? 1 : 0), 180 * (SpinAxis == Axis.y ? 1 : 0), 180 * (SpinAxis == Axis.z ? 1 : 0));
            ret.Append(toMove.transform.DORotate(rot, TimeToGetToNode / NumberOfSpins / 2, RotateMode.FastBeyond360));
        }
        ret.Append(toMove.transform.DORotate(transform.rotation.eulerAngles, TimeToGetToNode / NumberOfSpins / 2, RotateMode.FastBeyond360));
        return ret;
    }
}
