using UnityEditor.UIElements;
using UnityEngine;

public class TileUnit : MonoBehaviour
{
    [SerializeField] Vector2 flagDirection, noFlagDirection, currentDirection, gridPos;
    public void UpdateDirection(bool flag)
    {
        if (flag) currentDirection = flagDirection;
        else currentDirection = noFlagDirection;
        
    }
    public Vector2 GetDirection()
    {
        return currentDirection;
    }
}
