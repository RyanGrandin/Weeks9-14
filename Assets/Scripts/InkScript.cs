using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class InkScript : MonoBehaviour
{
    public Image penIMG;
    public RectTransform penRectTransform;
    Vector2 newPensition = new Vector2();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        penRectTransform.position = newPensition;
    }

    public void BlackInquip()
    {
        penIMG.color = Color.black;
    }

    public void RedInquip()
    {
        penIMG.color = Color.red;
    }

    public void BlueInquip()
    {
        penIMG.color = Color.blue;
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        newPensition = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }
}
