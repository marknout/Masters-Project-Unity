using UnityEngine;

public class PanZoom : MonoBehaviour
{
    Vector3 touchStart;
    public float zoomOutMin = 1;
    public float zoomOutMax = 8;
    public float zoomSpeed = 0.05f;

    public float minX, minY, maxX, maxY;

    public bool lockX;
    public bool lockY;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * zoomSpeed);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            /*direction.x = Mathf.Clamp(0, -0.39f, 0.42f);
            direction.y = Mathf.Clamp(0, -0.51f, 0.41f);*/

            if (lockX)
            {
                direction.x = 0;
            }
            if (lockY)
            {
                direction.y = 0;
            }

            transform.position += direction;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY));
        }
        zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    void zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }
}
