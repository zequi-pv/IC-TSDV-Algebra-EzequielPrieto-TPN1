using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingScript : MonoBehaviour
{

    [SerializeField] LineRenderer line;

    Vector3 worldPosition;
    Vector3 mousePosition;

    private void Start()
    {
        line.loop = false;
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;
            worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            if (line.positionCount == 1 && line.GetPosition(0) == new Vector3(0, 0, 0))
                line.SetPosition(0, new Vector3(worldPosition.x, worldPosition.y, 1));
            else
            {
                line.positionCount += 1;
                line.SetPosition(line.positionCount - 1, new Vector3(worldPosition.x, worldPosition.y, 1));
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            line.positionCount += 1;
            line.SetPosition(line.positionCount - 1, line.GetPosition(0));
        }
    }
}
