using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 hoverPrefabSize = new (1.2f, 1.2f, 1.2f);
    public Vector3 hoverColliderSize = new (1.2f, 1.2f, 1.2f);

    private Vector3 normalPrefabSize;
    private Vector3 normalColliderSize;
    private BoxCollider boxCollider;
    private Coroutine animationCoroutine;

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

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter!");
        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
        }
        animationCoroutine = StartCoroutine(AnimateScale(hoverPrefabSize, hoverColliderSize));
    }

    public void MouseEnterEvent(PointerEventData eventData)
    {
        Debug.Log("MouseEnterEvent!");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit!");
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
