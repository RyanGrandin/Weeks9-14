using UnityEngine;

public class HMonMovement : MonoBehaviour
{
    Vector2 bottomLeft;
    Vector2 topRight;
    public float speed = 1;

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

        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPos.x > Screen.width)
        {
            newPos.x = bottomLeft.x;
        }

        transform.position = newPos;
    }
}
