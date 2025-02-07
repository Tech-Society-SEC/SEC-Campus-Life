using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Sphere; 
    public float followDistance = 5f;
    public float height = 2f;
    public float rotationSpeed = 5f;

    void Start()
    {
        if (Sphere == null)
        {
            Debug.LogError("Sphere is not assigned to the CameraFollow script.");
        }
    }

    private void LateUpdate()
    {
        if (Sphere != null)
        {
            FollowSphere();
        }
    }

    void FollowSphere()
    {
        Vector3 targetPosition = Sphere.position - Sphere.forward * followDistance + Vector3.up * height;

        Debug.Log("Camera Target Position: " + targetPosition);

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * rotationSpeed);

        transform.LookAt(Sphere.position + Vector3.up * height); 
    }
}
