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

        CheckInside();
    }

    void CheckInside()
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

        if (raycastHit2Ds.Count % 2 != 0)
            GetComponent<SpriteRenderer>().color = Color.green;
        else
            GetComponent<SpriteRenderer>().color = Color.white;
    }

}
