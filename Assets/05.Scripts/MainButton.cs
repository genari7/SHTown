using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainButton : MonoBehaviour
{
	public Color loadToColor = Color.black;
	public float ChangeSpeed = 1f;

	public GameObject Window;
	public void Clicked_Button1()
	{

	}

	public void Clicked_Button2()
	{

	}

	public void Clicked_Button3()
	{
		Initiate.Fade("ArMap", loadToColor, ChangeSpeed);
		//SceneManager.LoadScene("ArMap");

	}

	public void Clicked_Button4()
	{

	}

	public void Clicked_CloseButton()
	{
		Window.SetActive(false);
	}

	public void Clicked_BackButton()
	{
		Initiate.Fade("Main", loadToColor, ChangeSpeed);
	}

	public void Clicked_DDoa()
	{

	}
	
	public void Clicked_DDoa_Close()
	{

	}

	public void Clicked_EggBab()
	{
		Debug.Log("계란밥클릭!");

	}

	public void CLicked_EggBab_Close()
	{
		this.gameObject.SetActive(false);
	}

}
