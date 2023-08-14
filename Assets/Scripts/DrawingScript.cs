using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingScript : MonoBehaviour
{

    [SerializeField] LineRenderer linePrefab;
    [SerializeField] LineRenderer line;
    //PolygonCollider2D polygonCollider;
    EdgeCollider2D edgeCollider2D;
    Vector3 worldPosition;
    Vector3 mousePosition;

    List<Vector2> vertices = new List<Vector2>();
    private void Start()
    {
        line = Instantiate(linePrefab);
        line.loop = false;

        //polygonCollider = line.GetComponent<PolygonCollider2D>();
        edgeCollider2D = line.GetComponent<EdgeCollider2D>();
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;
            worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            if (line.positionCount == 1 && line.GetPosition(0) == new Vector3(0, 0, 0))
            {
                line.SetPosition(0, new Vector3(worldPosition.x, worldPosition.y, 1));
                vertices.Add(new Vector2(worldPosition.x, worldPosition.y));
            }
            else
            {
                line.positionCount += 1;
                line.SetPosition(line.positionCount - 1, new Vector3(worldPosition.x, worldPosition.y, 1));
                vertices.Add(new Vector2(worldPosition.x, worldPosition.y));
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            line.positionCount += 1;
            line.SetPosition(line.positionCount - 1, line.GetPosition(0));
            line.loop = true;
            edgeCollider2D.SetPoints(vertices);
            //polygonCollider.SetPath(0, vertices);
            if (line.positionCount > 3)
                line = Instantiate(linePrefab);
        }
    }
}
