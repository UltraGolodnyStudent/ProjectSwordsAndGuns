using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TargetRotation
{
    private enum Side
    {
        Left = -1,
        Right = 1
    }

    private static Vector3 _target;
    private static Vector2 _one = Vector2.right, _two;
    private static Transform _thisTransform;

    public static void SetRotation(Vector3 target, Transform thisTransform) // В vector3 вставлять transform.position
    {
        _thisTransform = thisTransform;
        _target = target;
        float z = GetValueZ();
        _thisTransform.rotation = Quaternion.Euler(0, 0, z);
    }

    private static float GetValueZ()
    {
        _two = _target - _thisTransform.position;
        float scalarComposition = _one.x * _two.x + _one.y * _two.y;
        float mudelesComposition = _one.magnitude * _two.magnitude;
        float division = scalarComposition / mudelesComposition;
        return Mathf.Acos(division) * Mathf.Rad2Deg * (int)GetSide();
    }

    private static Side GetSide()
    {
        Side side = Side.Right;
        if (_two.y <= _one.y)
            side = Side.Left;
        return side;
    }
}
