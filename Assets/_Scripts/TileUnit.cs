using System;
using UnityEditor.UIElements;
using UnityEngine;

public class TrackUnit : MonoBehaviour
{
    [SerializeField] internal Vector2 direction, gridPos;
    public Vector2 GetDirection()
    {
        return direction;
    }
}

