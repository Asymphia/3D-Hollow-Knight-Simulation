using UnityEngine;

public class HeadNod : MonoBehaviour
{ 
    public Transform headBone; 
    public float speed = 2.0f; 
    public float amount = 5.0f;
    
    private Quaternion initialRotation;

    void Start()
    {
        if (headBone != null)
            initialRotation = headBone.localRotation;
    }

    void Update() 
    {
        if (headBone == null) return;
        
        float angle = Mathf.Sin(Time.time * speed) * amount;
        
        headBone.localRotation = initialRotation * Quaternion.Euler(angle, 0, 0);
    }
}
