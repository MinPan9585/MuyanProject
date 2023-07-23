using System.Collections;
using UnityEngine;

public class WallCollisionHandler : MonoBehaviour
{
    public float offsetAmount = 1f;
    public float animationTime = 1f;
    private Material wallMaterial;
    private float initialOffsetAmount;

    void Start()
    {
        wallMaterial = GetComponent<Renderer>().material;
        initialOffsetAmount = wallMaterial.GetFloat("_OffsetAmount");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            StartCoroutine(AnimateWallOffset());
        }
    }

    IEnumerator AnimateWallOffset()
    {
        float elapsedTime = 0f;
        while (elapsedTime < animationTime)
        {
            float newOffset = Mathf.Lerp(initialOffsetAmount, initialOffsetAmount + offsetAmount, elapsedTime / animationTime);
            wallMaterial.SetFloat("_OffsetAmount", newOffset);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        wallMaterial.SetFloat("_OffsetAmount", initialOffsetAmount + offsetAmount);
    }
}
