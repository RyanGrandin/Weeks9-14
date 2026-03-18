using System.Collections;
using UnityEngine;
using UnityEngine.AdaptivePerformance;

public class PerformScript : MonoBehaviour
{
    public Transform olbericTransform;
    public Transform performanceStartTransform;
    public Transform performanceEndTransform;
    public float performanceLength = 1;
    public AnimationCurve performanceCurve;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartPerformance()
    {
        StartCoroutine(Perform());
        StartCoroutine(DoVisualEffect());
    }

    IEnumerator Perform()
    {
        float t = 0;

        while (t < 1)
        {
            olbericTransform.position = Vector2.Lerp(performanceStartTransform.position, performanceEndTransform.position, t);
            t += Time.deltaTime/performanceLength;
            yield return null;
        }
    }

    IEnumerator DoVisualEffect()
    {

        yield return null;
    }
}
