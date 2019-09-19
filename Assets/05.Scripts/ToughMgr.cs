using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToughMgr : MonoBehaviour
{
	private Camera ARcam;
	private Ray ray;
	private RaycastHit hit;
	// Start is called before the first frame update
	void Start()
	{
		ARcam = GameObject.Find("ARCamera").GetComponent<Camera>();
	}

	// Update is called once per frame
	void Update()
	{
#if UNITY_EDITOR
		if (Input.GetMouseButtonDown(0))
		{
			ray = ARcam.ScreenPointToRay(Input.mousePosition);

			//특정레이어 충돌시 이벤트
			if (Physics.Raycast(ray, out hit, 100.0f, 1 << LayerMask.NameToLayer("EggBab")))
			{
				Debug.Log("Hit1");

				GameObject.Find("MainCanvas").transform.Find("ScrollPanel_Eggbab").gameObject.SetActive(true);
			}

			if (Physics.Raycast(ray, out hit, 100.0f, 1 << LayerMask.NameToLayer("DDoa")))
			{
				Debug.Log("Hit1");

				GameObject.Find("MainCanvas").transform.Find("ScrollPanel_DDoa").gameObject.SetActive(true);
			}

			if (Physics.Raycast(ray, out hit, 100.0f, 1 << LayerMask.NameToLayer("Beer")))
			{
				Debug.Log("Hit1");

				GameObject.Find("MainCanvas").transform.Find("ScrollPanel_Beer").gameObject.SetActive(true);
			}


		}

#endif


#if UNITY_ANDROID || UNITY_IOS
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			ray = ARcam.ScreenPointToRay(Input.GetTouch(0).position);

			if (Physics.Raycast(ray, out hit, 100.0f, 1 << LayerMask.NameToLayer("EggBab")))
			{
				Debug.Log("Hit1");

				GameObject.Find("MainCanvas").transform.Find("ScrollPanel_Eggbab").gameObject.SetActive(true);
			}

			if (Physics.Raycast(ray, out hit, 100.0f, 1 << LayerMask.NameToLayer("DDoa")))
			{
				Debug.Log("Hit1");

				GameObject.Find("MainCanvas").transform.Find("ScrollPanel_DDoa").gameObject.SetActive(true);
			}

			if (Physics.Raycast(ray, out hit, 100.0f, 1 << LayerMask.NameToLayer("Beer")))
			{
				Debug.Log("Hit1");

				GameObject.Find("MainCanvas").transform.Find("ScrollPanel_Beer").gameObject.SetActive(true);
			}
		}

	}
#endif

	}





