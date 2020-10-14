using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private float currentZoom,pitch,maxZoom,minZoom,zoomSpeed,currentYaw,YawSpeed,currentAngle;


    void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        currentYaw += Input.GetAxis("Horizontal") * YawSpeed * Time.deltaTime;
        currentAngle += Input.GetAxis("Vertical") * YawSpeed * Time.deltaTime;
         
    }

    void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, currentYaw);
    }

}
