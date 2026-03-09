using UnityEngine;

public class TrackManager : MonoBehaviour
{
    [SerializeField] bool isFlagged;
    IUpdateable[] updateableTracks;
    public void toggleFlag()
    {
        isFlagged = !isFlagged;
        UpdateTracks();
    }

    void UpdateTracks()
    {
        foreach(IUpdateable updateable in updateableTracks)
        {
            updateable.UpdateTrack(isFlagged);
        }
    }

    void Start()
    {
        updateableTracks = GetComponentsInChildren<IUpdateable>();
    }
}

public interface IUpdateable
{
    public void UpdateTrack(bool flag);
}
