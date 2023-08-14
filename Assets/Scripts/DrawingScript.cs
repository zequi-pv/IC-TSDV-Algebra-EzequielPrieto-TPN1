using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingScript : MonoBehaviour
{

    [SerializeField] LineRenderer line;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (line.positionCount == 1)
                line.SetPosition(0, new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
            else
                line.SetPosition(line.positionCount - 1, new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));

            line.positionCount += 1;
        }
        if (Input.GetMouseButtonDown(1))
        {
            line.positionCount += 1;
            line.SetPosition(line.positionCount - 1, line.GetPosition(0));
        }
    }
}
