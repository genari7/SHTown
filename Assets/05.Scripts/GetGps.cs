using UnityEngine;

using UnityEngine.UI;

using System.Collections;

using System;



public class GetGps : MonoBehaviour

{

	private double init_lati = 35.135159;
	private double init_long = 126.7901045;

	public static GetGps Instance { set; get; }

	public double m_latitude;

	public double m_longitude;

	public double t_latitude = 35.135159;

	public double t_longitude = 126.7901045;

	public GameObject player;



	public Text coordinates;

	public Text debugText;



	int count = 0;



	private void Start()

	{

		Instance = this;

#if UNITY_EDITOR

#else

        StartCoroutine(StartLocationService());

#endif

	}

	

    private void Update()

    {

        coordinates.text = "Current (Lat,Lon): " + GetGps.Instance.m_latitude.ToString() + " - " + GetGps.Instance.m_longitude.ToString();

		
		double L_temp = (m_latitude - init_lati) / 0.00286;
		double G_temp = ((m_longitude - init_long) / 0.002054) * 0.564;


		Debug.Log("z = " + L_temp + "  x = " + G_temp);
		

		Vector3 Pos = player.transform.localPosition ;
		Pos.z = (float)(L_temp -0.5);
		Pos.x = (float)(G_temp -0.282);

        player.transform.localPosition = Pos;
		
			

	}

    private double distanceBetweenTwoPoints(double value1, double value2)

    {

        return Math.Abs(value1 - value2);

    }

    



	private IEnumerator StartLocationService()

	{

		Input.location.Start(0.5f);



		if (!Input.location.isEnabledByUser)

		{

			Debug.Log("User has not enabled GPS");

			// debugText.text = "User has not enabled GPS : " + count++.ToString();



			StartCoroutine(waitCor());

			yield break;

		}



		//  Input.location.Start();



		int maxWait = 20;

		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)

		{

			// debugText.text = "Wait : " + count++.ToString();

			yield return new WaitForSeconds(0.2f);

			maxWait--;

		}



		if (maxWait <= 0)

		{

			Debug.Log("Timed out");

			// debugText.text = "Timed out : " + count++.ToString();



			StartCoroutine(waitCor());

			yield break;

		}



		if (Input.location.status == LocationServiceStatus.Failed)

		{

			Debug.Log("Unable to determin device location");

			// debugText.text = "Unable to determin device location : " + count++.ToString();



			StartCoroutine(waitCor());

			yield break;

		}



		m_latitude = Input.location.lastData.latitude;

		m_longitude = Input.location.lastData.longitude;



		// debugText.text = "ok : " + count++.ToString();



		StartCoroutine(waitCor());

		yield break;

	}



	IEnumerator waitCor()

	{

		yield return new WaitForSeconds(0.2f);

		StartCoroutine(StartLocationService());

	}

}
