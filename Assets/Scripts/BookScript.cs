using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class BookScript : MonoBehaviour
{
    Vector2 mousePos;
    public SpriteRenderer drawingSR;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Click!");
            mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            if (drawingSR.bounds.Contains(mousePos))
            {
                Debug.Log("Click in bound!");
                StartCoroutine(AddRed());
                StartCoroutine(RemoveBlue());
            }
        }
    }

    IEnumerator AddRed()
    {
        float r = drawingSR.color.r;

        while (r < 255)
        {
            r += Time.deltaTime;
            drawingSR.color = new Color(r, drawingSR.color.g, drawingSR.color.b);
            yield return null;
        }
    }

    IEnumerator RemoveBlue()
    {
        float b = drawingSR.color.b;

        while (b > 190)
        {
            b -= Time.deltaTime;
            drawingSR.color = new Color(drawingSR.color.r, drawingSR.color.g, b);
            yield return null;
        }
    }
}
