using UnityEngine;

public class PanoramicScreenshot : MonoBehaviour
{
    public int numberOfScreenshots = 12; // Liczba zrzutów ekranu do wykonania
    public float rotationSpeed = 5f; // Prędkość obrotu kamery

    private int currentScreenshotIndex = 0;
    private Quaternion initialRotation;
    private bool capturingY = true;
    private bool capturingX = false;

    void Start()
    {
        initialRotation = transform.rotation;
    }

    void Update()
    {
        if (capturingY)
        {
            RotateCamera(Vector3.up);
            TakeScreenshotY();
        }
        else if (capturingX)
        {
            RotateCamera(Vector3.right);
            TakeScreenshotX();
        }
    }

    void RotateCamera(Vector3 axis)
    {
        float angleIncrement = 360f / numberOfScreenshots;
        transform.Rotate(axis, rotationSpeed * Time.deltaTime);
    }

    void TakeScreenshotY()
    {
        float angleIncrement = 360f / numberOfScreenshots;
        if (Mathf.Abs(transform.eulerAngles.y - (currentScreenshotIndex * angleIncrement)) < rotationSpeed * Time.deltaTime)
        {
            string screenshotName = "Screenshot_Y_" + currentScreenshotIndex + ".png";
            ScreenCapture.CaptureScreenshot(screenshotName);
            currentScreenshotIndex++;

            if (currentScreenshotIndex >= numberOfScreenshots)
            {
                capturingY = false;
                capturingX = true;
                currentScreenshotIndex = 0;
                transform.rotation = initialRotation; // Zresetuj rotację kamery
            }
        }
    }

    void TakeScreenshotX()
    {
        float angleIncrement = 360f / numberOfScreenshots;
        if (Mathf.Abs(transform.eulerAngles.x - (currentScreenshotIndex * angleIncrement)) < rotationSpeed * Time.deltaTime)
        {
            string screenshotName = "Screenshot_X_" + currentScreenshotIndex + ".png";
            ScreenCapture.CaptureScreenshot(screenshotName);
            currentScreenshotIndex++;

            if (currentScreenshotIndex >= 2*numberOfScreenshots)
            {
                capturingX = false;
            }
        }
    }
}
