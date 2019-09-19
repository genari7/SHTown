using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{

	private LineRenderer lineRenderer;
	private float counter;
	private float dist;

	public Transform origin1;
	public Transform destination1;

	public float lineDrawSpeed = 6f;
	public Color color;

	private bool isCreateLine = true;

    // Start is called before the first frame update
    void Start()
    {
		
		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.SetPosition(0, origin1.position);
		
		lineRenderer.SetWidth(.1f, .1f);
		lineRenderer.SetColors(Color.yellow, Color.yellow);

		
    }

    // Update is called once per frame

    void Update()
    {
		dist = Vector3.Distance(origin1.position, destination1.position);
		if (counter<dist)
		{

			
			counter += 0.1f / lineDrawSpeed;
			float x = Mathf.Lerp(0, dist, counter);

			Vector3 pointA = origin1.position;
			Vector3 pointB = destination1.position;
			Vector3 pointAlongLine = x * Vector3.Normalize(pointB - pointA) + pointA;
			//if (pointB == pointAlongLine)
			//{
			//	origin = destination1;
			//	destination1 = destination2;
			//	destination2 = null;
			//	if(isCreateLine)
			//	{
			//		
			//		
			//	
			//
			//	}
			//}
			lineRenderer.SetPosition(1, pointAlongLine);
			//Debug.Log("테스트 로그 = " + pointAlongLine);
			
		}
		else
		{
			lineRenderer.SetPosition(0, origin1.position);
			lineRenderer.SetPosition(1, destination1.position);
		}
		

		//Debug.Log("테스트 로그 = " + counter);

	}
}
