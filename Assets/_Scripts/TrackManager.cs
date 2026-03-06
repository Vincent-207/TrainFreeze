using UnityEngine;

public class TrackManager : MonoBehaviour
{
    [SerializeField] bool isFlagged;

    public void toggleFlag()
    {
        isFlagged = !isFlagged;
    }
}
