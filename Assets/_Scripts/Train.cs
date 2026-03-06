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
        TileUnit square = null;
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, 0.5f, transform.forward, 0.0001f);
        foreach(RaycastHit2D hit in hits)
        {
            square = hit.collider.GetComponent<TileUnit>();
            if(square != null)
            {
                Debug.Log("Found square!");
                break;
            }
        }
        if(square == null)
        {
            Debug.LogWarning("Can't find square, stopping.");
            yield break;
        }
        square.UpdateDirection(isFlagged);
        Vector2 currentDirection = square.GetDirection();
        
        float timeToDo = 1f;
        float duration = timeToDo;
        while(duration > 0f)
        {
            duration -= Time.deltaTime;
            // Move towards it.
            Vector2 newPos = ( (Vector2)transform.position) + (currentDirection * Time.deltaTime * (1 / timeToDo));
            transform.position = newPos;
            // rotate towards direction
            float angle = Mathf.Atan2(currentDirection.y, currentDirection.x) * Mathf.Rad2Deg;
		    transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
            yield return null;
        }

        // Correct to be at exact end pos;
        transform.position = square.transform.position + (Vector3) currentDirection;
        yield return null;

        StartCoroutine(DoUnitMove());
    }
}
