using UnityEngine;

public class LegWaver : MonoBehaviour
{
    [Header("Kości nóg")]
    public Transform leftLegBone;
    public Transform rightLegBone;

    [Header("Ustawienia ruchu")]
    public float speed = 3.0f;    // Jak szybko mają machać
    public float amount = 15.0f;   // O ile stopni mają się wychylać
    
    private Quaternion leftInitialRot;
    private Quaternion rightInitialRot;

    void Start()
    {
        if (leftLegBone) leftInitialRot = leftLegBone.localRotation;
        if (rightLegBone) rightInitialRot = rightLegBone.localRotation;
    }

    void Update()
    {
        if (leftLegBone == null || rightLegBone == null) return;
        
        float waveLeft = Mathf.Sin(Time.time * speed);
        float waveRight = Mathf.Sin(Time.time * speed + Mathf.PI);
        
        float angleLeft = Mathf.Clamp(waveLeft, 0, 1) * amount;
        float angleRight = Mathf.Clamp(waveRight, 0, 1) * amount;
        
        leftLegBone.localRotation = leftInitialRot * Quaternion.Euler(0, 0, -angleLeft);
        rightLegBone.localRotation = rightInitialRot * Quaternion.Euler(0, 0, angleRight);
    }
}
