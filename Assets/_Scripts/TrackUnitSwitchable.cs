using UnityEngine;

public class TrackUnitSwitchable : TrackUnit, IUpdateable
{
    [SerializeField] internal Vector2 noFlagDirection, flagDirection;
    void Start()
    {
        direction = noFlagDirection;
    }
    public void UpdateTrack(bool flag)
    {
        direction = flag ? flagDirection : noFlagDirection;
    }
}

