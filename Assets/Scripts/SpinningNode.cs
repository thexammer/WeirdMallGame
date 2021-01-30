using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SpinningNode : PathNode
{
    private readonly int NUMBER_OF_SPINS = 50;
    protected override Color GizmoColor => Color.green;

    public override Sequence MoveToNode(GameObject toMove)
    {
        Sequence ret = DOTween.Sequence();
        Vector3 orgiScale = transform.localScale;
        ret.Append(toMove.transform.DOScale(Vector3.zero, TimeToGetToNode / 2));
        ret.AppendCallback(() => toMove.transform.position = transform.position);
        ret.Append(toMove.transform.DOScale(orgiScale, TimeToGetToNode / 2));
        ret.Insert(0, MakeItSpin(toMove));
        return ret;
    }

    private Sequence MakeItSpin(GameObject toMove)
    {
        Sequence ret = DOTween.Sequence();
        for (int i = 0; i < NUMBER_OF_SPINS; ++i)
        {
            ret.Append(toMove.transform.DORotate(Vector3.zero, TimeToGetToNode / NUMBER_OF_SPINS / 2, RotateMode.FastBeyond360));
            ret.Append(toMove.transform.DORotate(new Vector3(0, 180, 0), TimeToGetToNode / NUMBER_OF_SPINS / 2, RotateMode.FastBeyond360));
        }
        ret.Append(toMove.transform.DORotate(transform.rotation.eulerAngles, TimeToGetToNode / NUMBER_OF_SPINS / 2, RotateMode.FastBeyond360));
        return ret;
    }
}
