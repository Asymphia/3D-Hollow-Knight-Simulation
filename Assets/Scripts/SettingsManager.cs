using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    [Header("Camera References")]
    public Camera mainCamera;
    public Transform viewLamp;
    public Transform viewKnight;
    public Transform viewShade;
    
    private Vector3 defaultPosition;
    private Quaternion defaultRotation;

    [Header("Lights")]
    public Light leftLamp;
    public Light rightLamp;
    public Slider sliderLeftLamp;
    public Slider sliderRightLamp;

    [Header("FPS Counter")]
    public TextMeshProUGUI fpsText;
    private float deltaTime = 0.0f;

    void Awake()
    {
        if (mainCamera != null)
        {
            defaultPosition = mainCamera.transform.position;
            defaultRotation = mainCamera.transform.rotation;
        }
    }

    void Start()
    {
        // Ustawienie sliderów na wartości świateł (np. 9000)
        if (leftLamp != null) sliderLeftLamp.value = leftLamp.intensity;
        if (rightLamp != null) sliderRightLamp.value = rightLamp.intensity;
    }

    void Update()
    {
        // FPS Counter
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = $"FPS: {Mathf.Ceil(fps)}";
    }

    // --- Zmiana Widoków ---

    public void SetViewDefault()
    {
        mainCamera.transform.position = defaultPosition;
        mainCamera.transform.rotation = defaultRotation;
    }

    public void SetViewLamp() => SetCam(viewLamp);
    public void SetViewKnight() => SetCam(viewKnight);
    public void SetViewShade() => SetCam(viewShade);

    private void SetCam(Transform target)
    {
        if (target == null) return;
        mainCamera.transform.position = target.position;
        mainCamera.transform.rotation = target.rotation;
    }

    // --- Światła (0 - 9000) ---
    public void UpdateLeftLamp(float val) => leftLamp.intensity = val;
    public void UpdateRightLamp(float val) => rightLamp.intensity = val;
}