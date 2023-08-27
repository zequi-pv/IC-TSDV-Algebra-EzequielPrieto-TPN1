using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] float speed = 5;

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 dir = transform.right * x + transform.up * y;
        transform.Translate(transform.up * y * speed * Time.deltaTime);
        transform.Translate(transform.right * x * speed * Time.deltaTime);

        int linesRight = CheckInside();

        if (linesRight % 2 != 0 && linesRight != 0)
            GetComponent<SpriteRenderer>().color = Color.green;
        else
            GetComponent<SpriteRenderer>().color = Color.white;
    }

    void CheckInsideRaycast()
    {
        List<RaycastHit2D> raycastHit2Ds = new List<RaycastHit2D>();

        RaycastHit2D hit;
        Vector2 origin = transform.position;

        string name = null;
        while (origin.x < 8)
        {
            if (Physics2D.Raycast(origin, Vector2.right))
            {
                hit = Physics2D.Raycast(origin, Vector2.right);
                if (name == null || hit.transform.name == name)
                {
                    raycastHit2Ds.Add(hit);
                    origin.x = hit.point.x + 0.2f;
                    name = hit.transform.name;
                }
            }
            else
                break;
        }

        if (raycastHit2Ds.Count % 2 != 0 && raycastHit2Ds.Count != 0)
            GetComponent<SpriteRenderer>().color = Color.green;
        else
            GetComponent<SpriteRenderer>().color = Color.white;
    }

    int CheckInside()
    {
        int collisionsCount = 0;
        foreach (LineRenderer line in FindObjectsOfType<LineRenderer>())
        {
            for (int i = 0; i < line.positionCount; i++)
            {
                bool isRight = false;
                Vector2 upperPointPos;
                Vector2 lowerPointPos;

                if (i == line.positionCount - 1)
                {
                    if (line.GetPosition(i).y < line.GetPosition(0).y)
                    {
                        lowerPointPos = line.GetPosition(i);
                        upperPointPos = line.GetPosition(0);
                    }
                    else
                    {
                        lowerPointPos = line.GetPosition(0);
                        upperPointPos = line.GetPosition(i);
                    }
                }
                else
                {
                    if (line.GetPosition(i).y < line.GetPosition(i + 1).y)
                    {
                        lowerPointPos = line.GetPosition(i);
                        upperPointPos = line.GetPosition(i + 1);
                    }
                    else
                    {
                        lowerPointPos = line.GetPosition(i + 1);
                        upperPointPos = line.GetPosition(i);
                    }
                }
                isRight = 0 >= (transform.position.x - upperPointPos.x) * (lowerPointPos.y - upperPointPos.y) - (transform.position.y - upperPointPos.y) * (lowerPointPos.x - upperPointPos.x);
                if (isRight && transform.position.y > lowerPointPos.y && transform.position.y < upperPointPos.y) collisionsCount++;
            }
        }
        return collisionsCount;
    }

}
