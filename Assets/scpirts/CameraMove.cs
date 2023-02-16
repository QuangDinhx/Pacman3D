using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player; // đối tượng Player
    public float sensitivity = 2.0f; // độ nhạy của chuột
    public float zoomSpeed = 2.0f; // tốc độ zoom
    public float minZoomDistance = 5f; // khoảng cách tối thiểu giữa camera và Player
    public float maxZoomDistance = 20f; // khoảng cách tối đa giữa camera và Player

    private Vector3 offset; // khoảng cách giữa camera và Player
    private float currentZoom = 0f; // giá trị zoom hiện tại
    private float currentX = 0f; // góc xoay theo trục X hiện tại
    private float currentY = 0f; // góc xoay theo trục Y hiện tại
    private Transform pivot; // transform của pivot để xoay camera quanh player

    private void Start()
    {
        // Tạo pivot và đặt vị trí tại player
        
        pivot = new GameObject("Pivot").transform;
        pivot.position = player.transform.position;

        // Tính toán khoảng cách ban đầu giữa camera và Player
        offset = transform.position - player.transform.position;
        
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameObject.FindAnyObjectByType<GameManager>().isGameStart)
        {
            // khóa chuột
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        if(!GameObject.FindAnyObjectByType<GameManager>().isGameStart){
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }


    private void LateUpdate()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed; // Tính toán giá trị zoom

        // Giới hạn khoảng cách giữa camera và Player trong khoảng từ minZoomDistance đến maxZoomDistance
        currentZoom = Mathf.Clamp(currentZoom, -maxZoomDistance, -minZoomDistance);

        // Áp dụng giá trị zoom vào khoảng cách camera
        offset = new Vector3(0f, -currentZoom, -Mathf.Abs(currentZoom));

        currentX += Input.GetAxis("Mouse X") * sensitivity; // Tính toán giá trị xoay theo trục X
        currentY -= Input.GetAxis("Mouse Y") * sensitivity; // Tính toán giá trị xoay theo trục Y
        currentY = Mathf.Clamp(currentY, -90f, 90f); // Giới hạn góc xoay Y trong khoảng từ -90 đến 90 độ

        // Tạo rotation cho pivot
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0f);

        // Cập nhật vị trí pivot tại player
        pivot.position = player.transform.position;

        // Di chuyển pivot tới vị trí mới
        transform.position = pivot.position + rotation * offset;

        // Xoay camera quanh pivot
        transform.LookAt(pivot);

        // Vector3 lookDirection = new Vector3(transform.forward.x, 0, transform.forward.z).normalized;
        // player.GetComponent<Player>().direction = lookDirection;
        
    }
}
