using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{

    private Transform camTr;
    private Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        camTr = GameObject.Find("ARCamera").GetComponent<Transform>();
        tr = GetComponent<Transform>();
		tr.localScale = new Vector3(-tr.localScale.x, tr.localScale.y, -tr.localScale.z);


	}

    // Update is called once per frame
    void Update()
    {
        tr.LookAt(camTr.position);
		//tr.localScale = new Vector3(-tr.localScale.x, tr.localScale.y, -tr.localScale.z);
		//tr.localScale = new Vector3(-1, 1, -1);
		//tr.eulerAngles = new Vector3(0, -1, 0);
	}
}
