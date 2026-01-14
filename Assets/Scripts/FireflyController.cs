using UnityEngine;

public class FireflyController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 1.0f;
    public float moveRange = 0.04f;

    [Header("Glow Settings")]
    public MeshRenderer fireflyRenderer;
    public float minIntensity = 0.5f;
    public float maxIntensity = 2f;
    public float glowSpeed = 1.33f;

    private Vector3 startPosition;
    private Material fireflyMaterial;
    private Color originalEmissionColor;
    private float randomOffset;

    void Start()
    {
        startPosition = transform.localPosition;

        if (fireflyRenderer != null)
        {
            fireflyMaterial = fireflyRenderer.material;
            originalEmissionColor = fireflyMaterial.GetColor("_EmissionColor");
        }
        
        randomOffset = Random.Range(0f, 100f);
    }

    void Update()
    {
        float time = Time.time + randomOffset;
        
        float x = Mathf.Sin(time * moveSpeed) * moveRange;
        float y = Mathf.Cos(time * moveSpeed * 0.7f) * moveRange;
        float z = Mathf.Sin(time * moveSpeed * 1.2f) * (moveRange * 0.5f);
        transform.localPosition = startPosition + new Vector3(x, y, z);
        
        if (fireflyMaterial != null)
        {
            float pulse = (Mathf.Sin(time * glowSpeed) + 1.0f) / 2.0f;
            float currentIntensity = Mathf.Lerp(minIntensity, maxIntensity, pulse);
            fireflyMaterial.SetColor("_EmissionColor", originalEmissionColor * currentIntensity);
            fireflyMaterial.EnableKeyword("_EMISSION");
        }
    }
}