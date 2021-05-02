using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{
    private void Start() => StartCoroutine(ExpandFromSingularity());

    private IEnumerator ExpandFromSingularity()
    {
        var startScale = Vector3.zero;
        var finishScale = transform.localScale;

        for (var percentage = 0f; percentage <= 1f; percentage += 0.01f)
        {
            transform.localScale = Vector3.Lerp(startScale, finishScale, percentage);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
