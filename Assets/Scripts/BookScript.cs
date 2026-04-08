using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BookScript : MonoBehaviour
{
    Vector2 mousePos;
    public SpriteRenderer drawingSR;
    public List<SpriteRenderer> pg1Panels;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < pg1Panels.Count; i++)
        {
            pg1Panels[i].color = new Color(pg1Panels[i].color.r, pg1Panels[i].color.g, pg1Panels[i].color.b, 0);
        }
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
                StartCoroutine(IncreaseAlpha());
            }
        }
    }

    IEnumerator IncreaseAlpha()
    {
        float a = drawingSR.color.a;

        while (a < 255)
        {
            a += Time.deltaTime;
            drawingSR.color = new Color(drawingSR.color.r, drawingSR.color.g, drawingSR.color.b, a);
            yield return null;
        }
    }
}
