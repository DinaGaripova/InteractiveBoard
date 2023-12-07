using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.IO;

public class CleanBob : MonoBehaviour
{
   // private Paint currentLine;
    [SerializeField] private GameObject bob;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit Hit;
                if (Physics.Raycast(ray, out Hit))
                {
                    if (Hit.collider.tag == "Player")
                    {
                        CleanLine();
                        
                    }
                    else if (Hit.collider.tag == "All")
                    {
                        CleanLineAll();

                    }

                }
            }
        }
        void CleanLine()
        {
            Paint.currentLine.positionCount = 0;
        }
        void CleanLineAll()
        {
            LineRenderer[] lines = FindObjectsOfType<LineRenderer>();
            foreach (LineRenderer line in lines)
            {
                Destroy(line.gameObject);
            }
            
        }
    }
}
