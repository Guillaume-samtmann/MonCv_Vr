using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class videointeract : MonoBehaviour
{
    public HandRayCast handRayCast;
    public InputActionProperty triggerAction;

    [Header("Clic affiche")]
    public GameObject JurassicPark;
    public GameObject TokyoDrift;
    public GameObject Rocky4;
    public GameObject WillHunting;
    public GameObject HungerGames;
    public GameObject PlaneteSinge;
    public GameObject JurassicWorld;
    public GameObject Comte;
    public GameObject RobotSauvage;
    public GameObject Creed2;


    [Header("Video")]
    public GameObject videoJurassicPark;
    public GameObject videoTokyoDrift;
    public GameObject videoRocky4;
    public GameObject videoWillHunting;
    public GameObject videoHungerGames;
    public GameObject videoPlaneteSinge;
    public GameObject videoJurassicWorld;
    public GameObject videoComte;
    public GameObject videoRobotSauvage;
    public GameObject videoCreed2;
    private void OnEnable()
    {
        triggerAction.action.performed += OnInteract;
        triggerAction.action.Enable();
    }

    private void OnDisable()
    {
        triggerAction.action.performed -= OnInteract;
        triggerAction.action.Disable();
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        Component target = handRayCast.ObjectInRay();
        if (target is Button button)
        {
            if (button.gameObject.name == "ButtonJurassic")
            {
                button.onClick.Invoke();
                ShowVideoJurassic();
            } else if (button.gameObject.name == "Button-compteMonteCristo")
            {
                button.onClick.Invoke();
                ShowVideoComte();
            }
            else if (button.gameObject.name == "Button-willHunting")
            {
                button.onClick.Invoke();
                ShowVideoWillHunting();
            }
            else if (button.gameObject.name == "Button-Creed2")
            {
                button.onClick.Invoke();
                ShowVideoCreed2();
            }
            else if (button.gameObject.name == "Button-tokyoDrift")
            {
                button.onClick.Invoke();
                ShowVideoTokyoDrift();
            }
            else if (button.gameObject.name == "Button-jurassicWorld2")
            {
                button.onClick.Invoke();
                ShowVideojurassicWorld2();
            }
            else if (button.gameObject.name == "Button-rocky4")
            {
                button.onClick.Invoke();
                ShowVideoRocky4();
            }
            else if (button.gameObject.name == "Button-robotSauvage")
            {
                button.onClick.Invoke();
                ShowVideoRobotSauvage();
            }
            else if (button.gameObject.name == "Button-planeteSinges")
            {
                button.onClick.Invoke();
                ShowVideoPlaneteSinges();
            }
            else if (button.gameObject.name == "Button-hungerGames")
            {
                button.onClick.Invoke();
                ShowVideoHungerGames();
            }
            else if(button.gameObject.name == "Button-sorti")
            {
                button.onClick.Invoke();
                LoadScene1();
            }
        }
    }

    public void LoadScene1()
    {
        SceneManager.LoadScene(0);
    }
    public void ShowVideoHungerGames()
    {
        videoJurassicPark.SetActive(false);
        videoTokyoDrift.SetActive(false);
        videoRocky4.SetActive(false);
        videoWillHunting.SetActive(false);
        videoHungerGames.SetActive(true);
        videoPlaneteSinge.SetActive(false);
        videoJurassicWorld.SetActive(false);
        videoComte.SetActive(false);
        videoRobotSauvage.SetActive(false);
        videoCreed2.SetActive(false);
    }
    public void ShowVideoPlaneteSinges()
    {
        videoJurassicPark.SetActive(false);
        videoTokyoDrift.SetActive(false);
        videoRocky4.SetActive(false);
        videoWillHunting.SetActive(false);
        videoHungerGames.SetActive(false);
        videoPlaneteSinge.SetActive(true);
        videoJurassicWorld.SetActive(false);
        videoComte.SetActive(false);
        videoRobotSauvage.SetActive(false);
        videoCreed2.SetActive(false);
    }
    public void ShowVideoRobotSauvage()
    {
        videoJurassicPark.SetActive(false);
        videoTokyoDrift.SetActive(false);
        videoRocky4.SetActive(false);
        videoWillHunting.SetActive(false);
        videoHungerGames.SetActive(false);
        videoPlaneteSinge.SetActive(false);
        videoJurassicWorld.SetActive(false);
        videoComte.SetActive(false);
        videoRobotSauvage.SetActive(true);
        videoCreed2.SetActive(false);
    }
    public void ShowVideoRocky4()
    {
        videoJurassicPark.SetActive(false);
        videoTokyoDrift.SetActive(false);
        videoRocky4.SetActive(true);
        videoWillHunting.SetActive(false);
        videoHungerGames.SetActive(false);
        videoPlaneteSinge.SetActive(false);
        videoJurassicWorld.SetActive(false);
        videoComte.SetActive(false);
        videoRobotSauvage.SetActive(false);
        videoCreed2.SetActive(false);
    }

    public void ShowVideojurassicWorld2()
    {
        videoJurassicPark.SetActive(false);
        videoTokyoDrift.SetActive(false);
        videoRocky4.SetActive(false);
        videoWillHunting.SetActive(false);
        videoHungerGames.SetActive(false);
        videoPlaneteSinge.SetActive(false);
        videoJurassicWorld.SetActive(true);
        videoComte.SetActive(false);
        videoRobotSauvage.SetActive(false);
        videoCreed2.SetActive(false);
    }
    public void ShowVideoTokyoDrift()
    {
        videoJurassicPark.SetActive(false);
        videoTokyoDrift.SetActive(true);
        videoRocky4.SetActive(false);
        videoWillHunting.SetActive(false);
        videoHungerGames.SetActive(false);
        videoPlaneteSinge.SetActive(false);
        videoJurassicWorld.SetActive(false);
        videoComte.SetActive(false);
        videoRobotSauvage.SetActive(false);
        videoCreed2.SetActive(false);
    }
    public void ShowVideoCreed2()
    {
        videoJurassicPark.SetActive(false);
        videoTokyoDrift.SetActive(false);
        videoRocky4.SetActive(false);
        videoWillHunting.SetActive(false);
        videoHungerGames.SetActive(false);
        videoPlaneteSinge.SetActive(false);
        videoJurassicWorld.SetActive(false);
        videoComte.SetActive(false);
        videoRobotSauvage.SetActive(false);
        videoCreed2.SetActive(true);
    }
    public void ShowVideoJurassic()
    {
        videoJurassicPark.SetActive(true);
        videoTokyoDrift.SetActive(false);
        videoRocky4.SetActive(false);
        videoWillHunting.SetActive(false);
        videoHungerGames.SetActive(false);
        videoPlaneteSinge.SetActive(false);
        videoJurassicWorld.SetActive(false);
        videoComte.SetActive(false);
        videoRobotSauvage.SetActive(false);
        videoCreed2.SetActive(false);
    }
    public void ShowVideoComte()
    {
        videoJurassicPark.SetActive(false);
        videoTokyoDrift.SetActive(false);
        videoRocky4.SetActive(false);
        videoWillHunting.SetActive(false);
        videoHungerGames.SetActive(false);
        videoPlaneteSinge.SetActive(false);
        videoJurassicWorld.SetActive(false);
        videoComte.SetActive(true);
        videoRobotSauvage.SetActive(false);
        videoCreed2.SetActive(false);
    }
    public void ShowVideoWillHunting()
    {
        videoJurassicPark.SetActive(false);
        videoTokyoDrift.SetActive(false);
        videoRocky4.SetActive(false);
        videoWillHunting.SetActive(true);
        videoHungerGames.SetActive(false);
        videoPlaneteSinge.SetActive(false);
        videoJurassicWorld.SetActive(false);
        videoComte.SetActive(false);
        videoRobotSauvage.SetActive(false);
        videoCreed2.SetActive(false);
    }

}
