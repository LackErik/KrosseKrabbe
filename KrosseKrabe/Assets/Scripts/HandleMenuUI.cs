using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleMenuUI : MonoBehaviour
{
    //public static bool MenuIsActive = false;
    public GameObject canvasMenuUI;
    public GameObject ingameUI;
    // public GameObject rezeptUI; evtl noch einbauen
    
    
    void Start()
    {
        // Zum Startzeitpunkt soll das Menü geschlossen sein
        canvasMenuUI.SetActive(false);
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { 
            if (canvasMenuUI.activeSelf) { 
                CloseMenuByEsc();
                ingameUI.SetActive(true);
            } else { 
                OpenMenuByEsc();
                ingameUI.SetActive(false);
            } 
        }
    }

    // Open Menü
    public void OpenMenuByEsc() { 
        if (Input.GetKeyDown(KeyCode.Escape)) {
            // Menü aktivieren
            canvasMenuUI.SetActive(true);
            // Mouse Interaktion solange das Menü offen ist erlauben sonst wie "inGame"
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    // Close Menü
    public void CloseMenuByEsc() {
        // Wenn Menü aktive und esc wieder gedrückt wird...
        if (canvasMenuUI.activeSelf == true && Input.GetKeyDown(KeyCode.Escape)) { 
            canvasMenuUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }   
    }
    // Close Menü by Button
    public void CloseMenuByBotton() {
        canvasMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }


    // handle Scenes:
    public void ChangeSceneToLobby() {
        SceneManager.LoadScene("Lobby");
        canvasMenuUI.SetActive(false);
    }

    public void ChangeSceneToKitchen() {
        SceneManager.LoadScene("Kitchen");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void ReloadCurrentScene()
    {
        // Funktioniert leider nicht
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
