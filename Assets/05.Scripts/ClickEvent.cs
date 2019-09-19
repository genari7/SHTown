using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEvent : MonoBehaviour
{
	private GameObject CurrentTouch;
	private bool CheckActive = true;
	// Start is called before the first frame update
	void Start()
    {
        
    }

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Physics.Raycast(ray, out hit);

			if (hit.collider != null)
			{
				CurrentTouch = hit.transform.gameObject;
				//실행문
				CheckActive = CurrentTouch.GetComponent<CheckActive>().CheckTF;
				Debug.Log(CurrentTouch.name);
				CurrentTouch.transform.Find("Canvas").gameObject.SetActive(CheckActive);
				CurrentTouch.GetComponent<CheckActive>().CheckTF = !CheckActive;
			}
		}
	}


}
