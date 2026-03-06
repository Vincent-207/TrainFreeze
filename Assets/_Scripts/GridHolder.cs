using UnityEngine;

public class GridHolder : MonoBehaviour
{
    [SerializeField] GameObject GridUnitPrefab;
    [SerializeField] Color primaryUnitColor, secondaryUnitColor;
    [SerializeField] int GridWidth, GridHeight;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateGrid()
    {
        for(int y = 0; y < GridHeight; y++)
        {
            for(int x = 0; x < GridWidth; x++)
            {
                Vector2 SpawnPos = new(x, y);
                GameObject unit = Instantiate(GridUnitPrefab, SpawnPos, Quaternion.identity, transform);
                SpriteRenderer spriteRenderer = unit.GetComponent<SpriteRenderer>();
                if((y + x) % 2 == 0)
                {
                    spriteRenderer.color = primaryUnitColor;
                }
                else
                {
                    spriteRenderer.color = secondaryUnitColor;
                }
            }
        }
    }

    public void DeleteGrid()
    {
        int childCount = transform.childCount;
        for(int childIndex = 0; childIndex < childCount; childIndex++)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }


}
