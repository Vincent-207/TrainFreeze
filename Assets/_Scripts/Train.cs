using System.Collections;
using UnityEngine;

public class Train : MonoBehaviour
{
    public bool isMoving;
    bool isFlagged;
    [SerializeField] bool isDoingMove;
    public void ToggleFlag()
    {
        isFlagged = !isFlagged;
    }
    void Start()
    {
        StartCoroutine(DoUnitMove());
    }

    void Update()
    {
        
    }

    IEnumerator DoUnitMove()
    {
        // Get square
        TrackUnit track = null;
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, 0.5f, transform.forward, 0.0001f);
        foreach(RaycastHit2D hit in hits)
        {
            track = hit.collider.GetComponent<TrackUnit>();
            if(track != null)
            {
                Debug.Log("Found square!");
                break;
            }

            Goal goal = hit.collider.GetComponent<Goal>();
            if(goal != null)
            {
                HandleGoal(goal);
                yield break;
            }
        }
        if(track == null)
        {
            Debug.LogWarning("Can't find square, stopping.");
            yield break;
        }

        Vector2 currentDirection = track.GetDirection();
        
        float timeToDo = 1f;
        float duration = timeToDo;
        while(duration > 0f)
        {
            duration -= Time.deltaTime;
            MoveAndTurn(currentDirection, track.transform.position);
            yield return null;
        }

        // Correct to be at exact end pos;
        transform.position = track.transform.position + (Vector3) currentDirection;
        yield return null;

        StartCoroutine(DoUnitMove());
    }

    void MoveAndTurn(Vector2 currentDirection, Vector2 trackPos)
    {
        Vector2 newPos = ( (Vector2)transform.position) + (currentDirection * Time.deltaTime);
        float displacement = (newPos - trackPos).magnitude;
        if(displacement > 1f) newPos = trackPos + currentDirection;
        transform.position = newPos;
        // rotate towards direction
        float angle = Mathf.Atan2(currentDirection.y, currentDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
    }

    void HandleGoal(Goal goal)
    {
        Debug.Log("Goal!");
    }
}
