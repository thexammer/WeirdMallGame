using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LerpMoveNode : PathNode
{
    public int NumSteps;
    private List<int> stepNums = new List<int>(); // This is a dumb workaround for ensuring the step num is correct.

    protected override Color GizmoColor => Color.yellow;

    private Vector3 StartingPos;

    private Quaternion StartingRot;

    private void Start()
    {
        for (int i = 1; i <= NumSteps; ++i)
        {
            stepNums.Add(i);
        }
    }

    public override Sequence MoveToNode(GameObject toMove)
    {
        Sequence ret = DOTween.Sequence();
        StartingPos = toMove.transform.position;
        StartingRot = toMove.transform.rotation;
        ret.Append(MakeItLerp(toMove));
        return ret;
    }

    private Sequence MakeItLerp(GameObject toMove)
    {
        Sequence ret = DOTween.Sequence();
        foreach (int step in stepNums)
        {
            ret.AppendInterval(TimeToGetToNode / NumSteps);
            ret.AppendCallback(() => LerpStep(step, toMove));
        }
        return ret;
    }

    private void LerpStep(int step, GameObject toMove)
    {
        toMove.transform.position = Vector3.Lerp(StartingPos, transform.position, step / (float)NumSteps);
        toMove.transform.rotation = Quaternion.Lerp(StartingRot, transform.rotation, step / (float)NumSteps);
    }
}
