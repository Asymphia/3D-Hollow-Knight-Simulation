using UnityEngine;
using TMPro;

public class CollapseMenu : MonoBehaviour
{
    [Header("Components")]
    public RectTransform menuTransform; 
    public TextMeshProUGUI buttonText;

    [Header("Settings")]
    public float animationDuration = 0.3f;
    public float expandedY = 0f; 
    public float collapsedY = -300f;

    private bool isExpanded = true;
    private Coroutine animationCoroutine;

    public void ToggleMenu()
    {
        isExpanded = !isExpanded;
        
        if (buttonText != null)
        {
            buttonText.text = isExpanded ? "Collapse Menu" : "Expand Menu";
        }
        
        if (animationCoroutine != null) StopCoroutine(animationCoroutine);
        
        float targetY = isExpanded ? expandedY : collapsedY;
        animationCoroutine = StartCoroutine(AnimateVerticalStep(targetY));
    }

    private System.Collections.IEnumerator AnimateVerticalStep(float targetY)
    {
        float time = 0;
        float startY = menuTransform.anchoredPosition.y;
        float currentX = menuTransform.anchoredPosition.x;

        while (time < animationDuration)
        {
            time += Time.deltaTime;
            float t = Mathf.SmoothStep(0, 1, time / animationDuration);
            
            float newY = Mathf.Lerp(startY, targetY, t);
            menuTransform.anchoredPosition = new Vector2(currentX, newY);
            
            yield return null;
        }

        menuTransform.anchoredPosition = new Vector2(currentX, targetY);
    }
}
