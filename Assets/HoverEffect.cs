using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverEffect : MonoBehaviour
{
    public Vector3 hoverPrefabSize = new (1.5f, 1.5f, 1.5f);
    public Vector3 hoverColliderSize = new (1.5f, 1.5f, 1.5f);

    private Vector3 normalPrefabSize;
    private Vector3 normalColliderSize;
    private BoxCollider boxCollider;
    private Coroutine animationCoroutine;

    // init fork size
    private void Start()
    {
        normalPrefabSize = transform.localScale;
        boxCollider = GetComponent<BoxCollider>();

        if (boxCollider != null)
        {
            normalColliderSize = boxCollider.size;
        }
    }

    private void OnMouseEnter()
    {
        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
        }
        animationCoroutine = StartCoroutine(AnimateScale(hoverPrefabSize, hoverColliderSize));
    }

    private void OnMouseExit()
    {
        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
        }
        animationCoroutine = StartCoroutine(AnimateScale(normalPrefabSize, normalColliderSize));
    }

    private IEnumerator AnimateScale(Vector3 targetScale, Vector3 targetColliderSize)
    {
        float duration = 0.2f;
        float elapsedTime = 0;

        Vector3 initialScale = transform.localScale;
        Vector3 initialColliderSize = boxCollider != null ? boxCollider.size : Vector3.zero;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;

            transform.localScale = Vector3.Lerp(initialScale, targetScale, t);
            if (boxCollider != null)
            {
                boxCollider.size = Vector3.Lerp(initialColliderSize, targetColliderSize, t);
            }

            yield return null;
        }

        transform.localScale = targetScale;
        if (boxCollider != null)
        {
            boxCollider.size = targetColliderSize;
        }
    }
}
