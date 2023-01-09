using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleMenuUI : MonoBehaviour
{
    //public static bool MenuIsActive = false;
    public GameObject menuUI;
    public GameObject ingameUI;
    // Start is called before the first frame update
    void Start()
    {
        // Zum Strtzeitpunkt soll das Menü geschlossen sein
        menuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // 1. mal esc => Menü offen
        if (Input.GetKeyDown(KeyCode.Escape)) {
            // Menü aktivieren
            menuUI.SetActive(true);
            

            // Mouse Interaktion solange das Menü offen ist erlauben sonst wie "inGame"
            Cursor.lockState = CursorLockMode.Confined;
        }

        // andere UI verstecken wenn Menü offen
        if (menuUI.activeSelf) {
            ingameUI.SetActive(false);
        } else {
            ingameUI.SetActive(true);
        }
        
        

    }
    public void CloseMenuByBotton() {
        menuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // handle Scenes:
    public void ChangeSceneToLobby() {
        SceneManager.LoadScene("Lobby");
        menuUI.SetActive(false);
    }

    public void ChangeSceneToKitchen() {
        SceneManager.LoadScene("Kitchen");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
