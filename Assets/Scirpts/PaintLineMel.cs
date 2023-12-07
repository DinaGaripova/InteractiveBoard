using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintLineMel : MonoBehaviour
{
    public LineRenderer currentLine;
    private int numPoints = 0;
    private bool isObjectSelected = false;
    private Vector3 touchPositionOffset;
    [SerializeField] private GameObject bob;
    [SerializeField] private GameObject mel;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                
                DrawLine();
            }
        }
    }

    void DrawLine()
    {
        if (Input.touchCount > 0)
        {
            mel.SetActive(false);
            bob.SetActive(true);
            Touch touch = Input.GetTouch(0);
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(touch.position);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.gameObject == this.gameObject)
                {
                    isObjectSelected = true;
                    touchPositionOffset = this.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                }
            }
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
            else if (touch.phase == TouchPhase.Moved && isObjectSelected)
            {
                this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10)) + touchPositionOffset;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isObjectSelected = false;
            }
        }
    }
}
