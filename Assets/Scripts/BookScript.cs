using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BookScript : MonoBehaviour
{
    Vector2 mousePos;
    public List<SpriteRenderer> drawings;
    public Image penIMG;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // sets all of the drawings' alphas to 0 when the game starts
        for (int i = 0; i < drawings.Count; i++)
        {
            drawings[i].color = new Color(drawings[i].color.r, drawings[i].color.g, drawings[i].color.b, 0);
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
            mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            // checks drawings to see if the mouse is over any of their sprites' bounds
            for (int i = 0; i < drawings.Count; i++)
            {
                if (drawings[i].sprite.bounds.Contains(mousePos))
                {
                    drawings[i].color = new Color(penIMG.color.r, penIMG.color.g, penIMG.color.b, drawings[i].color.a);
                    StartCoroutine(IncreaseAlpha(drawings[i]));
                }
            }
        }
    }

    IEnumerator IncreaseAlpha(SpriteRenderer drawingSR)
    {
        float a = drawingSR.color.a;

        while (a < 255)
        {
            a += Time.deltaTime;
            
            // sets drawing to a new colour with an updated alpha value
            drawingSR.color = new Color(drawingSR.color.r, drawingSR.color.g, drawingSR.color.b, a);

            yield return null;
        }
    }
}
