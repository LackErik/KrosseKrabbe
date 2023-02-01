using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleMenuUI : MonoBehaviour
{
    //public static bool MenuIsActive = false;
    public GameObject menuUI;
    public GameObject ingameUI;
    
    
    void Start()
    {
        // Zum Startzeitpunkt soll das Menü geschlossen sein
        menuUI.SetActive(false);
    }

    void Update()
    {
        // 1. mal esc => Menü offen
        OpenMenuByEsc();

        // andere UI verstecken wenn Menü offen
        if (menuUI.activeSelf) {
            ingameUI.SetActive(false);
        } else {
            ingameUI.SetActive(true);
        }

        // 2. mal esc => Menü wieder schließen
        //CloseMenuByEsc();
    }

    // Open Menü
    public void OpenMenuByEsc() { 
        if (Input.GetKeyDown(KeyCode.Escape)) {
            // Menü aktivieren
            menuUI.SetActive(true);
            // Mouse Interaktion solange das Menü offen ist erlauben sonst wie "inGame"
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    // Close Menü
    public void CloseMenuByEsc() {
        // Wenn Menü aktive und esc wieder gedrückt wird...
        if (menuUI.activeSelf == true && Input.GetKeyDown(KeyCode.Escape)) { 
            menuUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
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
