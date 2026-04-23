using UnityEngine;

public class TankController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform turretPivot;
    [SerializeField] private Transform firePoint;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float turnSpeed = 90f;

    [Header("Combat")]
    [SerializeField] private float fireCooldown = 0.25f;
    [SerializeField] private float fireRange = 120f;
    [SerializeField] private LayerMask hitMask = ~0;

    [Header("Camera")]
    [SerializeField] private Vector3 topDownOffset = new Vector3(0f, 20f, -2f);
    [SerializeField] private float cameraFollowSmooth = 10f;
    [SerializeField] private Vector3 topDownEuler = new Vector3(75f, 0f, 0f);

    private float _nextFireTime;
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        HandleMovement();
        HandleTurretAim();
        HandleFire();
    }
    private void LateUpdate()
    {
        HandleCamera();
    }
    private void HandleCamera()
    {
        if (_mainCamera == null)
        {
            _mainCamera = Camera.main;
        }

        if (_mainCamera == null)
        {
            return;
        }

        Vector3 targetPos = transform.position + topDownOffset;
        _mainCamera.transform.position = Vector3.Lerp(
            _mainCamera.transform.position,
            targetPos,
            cameraFollowSmooth * Time.deltaTime
        );
        _mainCamera.transform.rotation = Quaternion.Euler(topDownEuler);
    }

    private void HandleMovement()
    {
        float moveInput = Input.GetAxis("Vertical");   // W/S or Up/Down
        float turnInput = Input.GetAxis("Horizontal"); // A/D or Left/Right

        transform.Translate(Vector3.forward * (moveInput * moveSpeed * Time.deltaTime), Space.Self);
        transform.Rotate(Vector3.up * (turnInput * turnSpeed * Time.deltaTime), Space.Self);
    }

    private void HandleTurretAim()
    {
        if (turretPivot == null || Camera.main == null)
        {
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, turretPivot.position);

        if (!groundPlane.Raycast(ray, out float enter))
        {
            return;
        }

        Vector3 hitPoint = ray.GetPoint(enter);
        Vector3 lookDir = hitPoint - turretPivot.position;
        lookDir.y = 0f;

        if (lookDir.sqrMagnitude < 0.001f)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(lookDir);
        turretPivot.rotation = Quaternion.RotateTowards(
            turretPivot.rotation,
            targetRotation,
            turnSpeed * 2f * Time.deltaTime
        );
    }

    private void HandleFire()
    {
        if (!Input.GetMouseButton(0) || Time.time < _nextFireTime)
        {
            return;
        }

        _nextFireTime = Time.time + fireCooldown;

        Transform origin = firePoint != null ? firePoint : turretPivot != null ? turretPivot : transform;
        Ray ray = new Ray(origin.position, origin.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, fireRange, hitMask))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red, 0.2f);
            Debug.Log($"Hit: {hit.collider.name}");
            return;
        }

        Debug.DrawRay(ray.origin, ray.direction * fireRange, Color.yellow, 0.2f);
    }
}
