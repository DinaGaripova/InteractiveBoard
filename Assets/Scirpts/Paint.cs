using UnityEngine;


public class Paint : MonoBehaviour
{
    public static LineRenderer currentLine;
    private int numPoints = 0;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                GameObject newLine = new GameObject("Line");
                currentLine = newLine.AddComponent<LineRenderer>();
                currentLine.material = new Material(Shader.Find("Sprites/Default"));
                currentLine.startWidth = 0.1f;
                currentLine.endWidth = 0.1f;
                currentLine.positionCount = 0;
                numPoints = 0;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                currentLine.positionCount = numPoints + 1;
                currentLine.SetPosition(numPoints, Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10)));
                numPoints++;
            }
        }
    }




}