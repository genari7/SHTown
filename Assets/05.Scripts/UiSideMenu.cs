using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;


namespace CustomUiElements
{
    public class UiSideMenu : MonoBehaviour
    {
        public float lat, lon;
        public Text Search;
        [Tooltip("Do we keep the side menu available through all the app?")]
        public bool KeepMenu;

        [Tooltip("Event system for the side menu. Only needed if KeepMenu = true")]
        public GameObject EventSystem;

        [Tooltip("The actual panel that slides and contains the menu")]
        public RectTransform MenuParent;
        private bool m_MenuActive = false;

        [Tooltip("Speed with which the menu opens/closes")]
        public float MenuSpeed = 0.03f;

        [Tooltip("If the menu is persistent through all the app, we can have background music")]
        public AudioSource BackgroundMusic;

        [Tooltip("Icon for when music is playing")]
        public Sprite MuteIcon;

        [Tooltip("Icon for when music is paused")]
        public Sprite PlayIcon;

        [Tooltip("Button to Play/Pause music")]
        public Image SideMenuMute;
   
        [Tooltip("Big invisible button to close menu by tapping outside")]
        public GameObject MenuCloser;

        void Awake()
        {
            // Since the side menu and event system can be persistent through the app, we ensure to have only 1
            if (GameObject.FindObjectsOfType<EventSystem>().Length > 1)
            {
                Destroy(EventSystem);
            }

            if (GameObject.FindObjectsOfType<UiSideMenu>().Length > 1)
            {
                Destroy(gameObject);
            }
            else if (KeepMenu)
            {
                DontDestroyOnLoad(gameObject);   
            }
        }

        public void ToggleMenu()
        {
            if (m_MenuActive)
            {
                StartCoroutine(HideMenu());
                m_MenuActive = false;
            }
            else
            {
                StartCoroutine(ShowMenu());
                m_MenuActive = true;
            }
        }

        public void Button1Clicked()
        {
            CallURL("관광지");
            Debug.Log("관광지 클릭!");
        }

        public void Button2Clicked()
        {
            CallURL("숙박");
            Debug.Log("숙박 클릭!");
        }

        public void Button3Clicked()
        {
            CallURL("식당");
            Debug.Log("식당 클릭!");
        }

        public void Button4Clicked()
        {
            CallURL("카페");
            Debug.Log("카페 클릭!");
        }

        public void Button5Clicked()
        {
            CallURL("병원");
            Debug.Log("병원 클릭!");
        }

        public void Button6Clicked()
        {
            CallURL("편의점");
            Debug.Log("편의점 클릭!");
        }


        public void ButtonSearch()
        {
            CallURL(Search.text);
            Debug.Log("검색 클릭!");
        }

        public void ButtonBack()
        {
            SceneManager.LoadScene("MainScene");

        }


        public void CallURL(string Filter)
        {
            //lat = csGetGPS.getLat;
            //lon = csGetGPS.getLon;
            //Application.OpenURL("https://www.google.com/maps/search/" + Filter + "/@" + lat + "," + lon + ",17z");
        }

        public void ForceHideMenu()
        {
            if (m_MenuActive)
            {
                StartCoroutine(HideMenu());
                m_MenuActive = false;
            }
        }

        

        
		//좌에서 우
		private IEnumerator ShowMenu()
		{
			float y = MenuParent.position.y;
			float z = MenuParent.position.z;
			while (MenuParent.pivot.x > 0)
			{
				float newX = MenuParent.pivot.x - MenuSpeed;
				MenuParent.pivot = new Vector2(newX, 1);
				MenuParent.position = new Vector3(0, y, z);
				yield return null;
			}
			MenuParent.pivot = new Vector2(0, 1);
			MenuParent.position = new Vector3(0, y, z);
			MenuCloser.SetActive(true);
			yield break;
		}

		
		//좌에서 우
		private IEnumerator HideMenu()
		{
			float y = MenuParent.position.y;
			float z = MenuParent.position.z;
			while (MenuParent.pivot.x < (1 - MenuSpeed))
			{
				float newX = MenuParent.pivot.x + MenuSpeed;
				MenuParent.pivot = new Vector2(newX, 1);
				MenuParent.position = new Vector3(0, y, z);
				yield return null;
			}
			MenuParent.pivot = new Vector2(1, 1);
			MenuParent.position = new Vector3(0, y, z);
			MenuCloser.SetActive(false);
			yield break;
		}

		public void ToggleBackgroundMusic()
        {
            if (BackgroundMusic != null)
            {
                if (BackgroundMusic.isPlaying)
                {
                    BackgroundMusic.Pause();
                    SideMenuMute.sprite = MuteIcon;
                }
                else
                {
                    BackgroundMusic.Play();
                    SideMenuMute.sprite = PlayIcon;
                }
            }
        }
     
        // Here you can add your custom logic, with what your side-menu buttons do:

        
     

        public void PrintToConsole(string text)
        {
            Debug.Log(text);
        }
    }
}