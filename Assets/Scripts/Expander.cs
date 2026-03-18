using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

public class Expander : MonoBehaviour
{
    public Transform treeTransform;
    public Transform appleTransform;
    public float appleDelay = 1;

    Coroutine doExpansionCoroutine;
    Coroutine expandTreeCoroutine;
    Coroutine expandAppleCoroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        treeTransform.localScale = Vector2.zero;
        appleTransform.localScale = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTreeExpansion()
    {
        if (doExpansionCoroutine != null)
        {
            StopCoroutine(doExpansionCoroutine);
        }
        if (expandTreeCoroutine != null)
        {
            StopCoroutine(expandTreeCoroutine);
        }
        if (expandAppleCoroutine != null)
        {
            StopCoroutine(expandAppleCoroutine);
        }

        doExpansionCoroutine = StartCoroutine(DoTheExpansion());
    }

    IEnumerator DoTheExpansion()
    {
        yield return expandTreeCoroutine = StartCoroutine(ExpandTree());
        yield return expandAppleCoroutine = StartCoroutine(ExpandApple());
    }

    IEnumerator ExpandTree()
    {
        Debug.Log("Started expanding tree.");
        
        treeTransform.localScale = Vector2.zero;
        appleTransform.localScale = Vector2.zero;

        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime;
            treeTransform.localScale = Vector2.one * t;
            yield return null;
        }

        Debug.Log("Finished expanding tree.");
    }

    IEnumerator ExpandApple()
    {
        Debug.Log("Started expanding apple.");

        appleTransform.localScale = Vector2.zero;

        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime;
            appleTransform.localScale = Vector2.one * t;
            yield return null;
        }

        Debug.Log("Finished expanding apple.");
    }
}
