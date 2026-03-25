using UnityEngine;

public class HMonMovement : MonoBehaviour
{
    Vector2 bottomLeft;
    Vector2 topRight;
    public float speed = 1;
    public AnimationCurve HMonCurve;
    public TrailRenderer tr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = transform.position;

        newPos.x += speed * Time.deltaTime;
        newPos.y = HMonCurve.Evaluate(newPos.x);

        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPos.x > Screen.width)
        {
            tr.emitting = false;
            Debug.Log("stop emitting");
            newPos.x = bottomLeft.x;
            tr.emitting = true;
            Debug.Log("start emitting");
        }

        transform.position = newPos;
    }
}
