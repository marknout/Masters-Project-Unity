using UnityEngine;

public class CameraAxisLock : MonoBehaviour
{
    public bool lockX;

    public bool lockY;

    public bool releaseOnExit;

    private void OnTriggerEnter(Collider other)
    {
        print("Enabling xLock: " + lockX + " and yLock: " + lockY);
        other.gameObject.GetComponent<PanZoom>().lockX = lockX;
        other.gameObject.GetComponent<PanZoom>().lockY = lockY;
    }

    private void OnTriggerExit(Collider other)
    {
        if (releaseOnExit)
        {
            print(gameObject.name + " disabling axis locks");
            other.gameObject.GetComponent<PanZoom>().lockX = false;
            other.gameObject.GetComponent<PanZoom>().lockY = false;
        }
    }
}
