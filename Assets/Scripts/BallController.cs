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
        int count = 0;
        List<RaycastHit2D> hits = new List<RaycastHit2D>();
        ContactFilter2D filter = new ContactFilter2D();
            filter.NoFilter();
        Vector3 origin = new Vector3(0, 0, 0);
        Vector3 finalPosition = new Vector3(transform.position.x + 30, transform.position.y, 0);

            Physics2D.Raycast(origin, Vector2.right, filter, hits, 1000);
        //while (origin != finalPosition)
        //{
        //    if ()
        //    {
        //        origin.x = hit.point.x + 0.5f;
        //        count++;
        //        Debug.Log("HIT");
        //    }
        //    else
        //        origin = finalPosition;
        //}
        Debug.Log(hits.Count);

        if (hits.Count % 2 != 0)
            GetComponent<SpriteRenderer>().color = Color.green;
        else
            GetComponent<SpriteRenderer>().color = Color.white;
    }

}
