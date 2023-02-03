using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RezeptUI : MonoBehaviour
{
    public GameObject rezeptUI;
    public GameObject ingameUI;

    private void Awake()
    {
        // RezeptUI deaktivieren
        rezeptUI.SetActive(true);
        // IngameUI deaktivieren
        ingameUI.SetActive(false);
    }
    private void Start()
    {
        // Spiel pausiert, damit sich nicht die "Sicht" bewegt
        Time.timeScale = 0;
    }

    private void Update()
    {
        // Solange die UI aktiv ist soll mausinteraktion an sein
        if (rezeptUI.activeSelf)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
    public void ButtonClickBeginnen()
    {
        // RezeptUI deaktivieren
        rezeptUI.SetActive(false);
        // IngameUI deaktivieren
        ingameUI.SetActive(true);
        // Spiel starten / Bewegung erlauben
        Time.timeScale = 1;
        // Maus interaktion verbieten
        Cursor.lockState = CursorLockMode.Locked;
        
    }

}
