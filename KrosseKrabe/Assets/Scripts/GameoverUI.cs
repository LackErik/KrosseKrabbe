using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameoverUI : MonoBehaviour
{
// ===> Initalisierung
    // GameoverUI
    public GameObject gameoverUICanvas;
    [SerializeField] private TextMeshProUGUI headerTxt;
    [SerializeField] private TextMeshProUGUI failedTxtBurnedPatty;
    [SerializeField] private TextMeshProUGUI failedTxtErrors;
    [SerializeField] private TextMeshProUGUI successTxt;

    //handle MenuUI
    public GameObject menuUI;

    // failed burned patty
    public GameObject burnedPatty;

    // failed by erros
    public float maxErrors;
    public Raycaster raycasterScript; // muss vom Raycasterscript kommen
    private int didErrors;

    // success when burger finished
    public GameObject burgerBunTop;
    public GameObject burgerBunTopPos;


    // ===> Methoden
    // Start is called before the first frame update
    void Start()
    {
        
        gameoverUICanvas.SetActive(false);
        //nur Canvas deaktivier, damit Script ausgeführt bleibt und Prüfungen statt finden können

        // nur der entsprechende Grund soll später erscheinen:
        headerTxt.text = "";
        failedTxtBurnedPatty.text = "";
        failedTxtErrors.text = "";
        successTxt.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        // GameoverUI mit passenden Text je nach Grund
        checkForBurnedPatty();
        checkForErrorCount();
        checkForSuccess();


        // didErrors prüfen
        didErrors = raycasterScript.errorCount;
    }

    void checkForBurnedPatty(){
        if(burnedPatty.activeSelf){
            handleGameover();
            headerTxt.text = "Failed!";
            failedTxtBurnedPatty.text = "Dein Patty ist verbrannt!";
        }
    }

    void checkForErrorCount()
    {
        if (maxErrors == didErrors)
        {
            handleGameover();
            headerTxt.text = "Failed!";
            failedTxtErrors.text = "Du hast " + didErrors + " von " + maxErrors + " Fehler gemacht";
        }
    }
    void checkForSuccess(){
        if(burgerBunTopPos.transform.position == burgerBunTop.transform.position)
        {
            handleGameover();
            headerTxt.text = "passed!";
            successTxt.text = "Du hast das Training erfolgreich bestanden!";
            // gameObject in der Lobby von Silberner Pfannenwender aktivieren 
        }
    }
    

    void handleGameover(){
        // gameoverUI muss angezeigt werden
        gameoverUICanvas.SetActive(true);
        // MenuUI soll nicht geöffnet werden dürfen (wenn gameoverUI == active)
        menuUI.SetActive(false);
        // Spiel pausiert, damit sich nicht die "Sicht" bewegt
        Time.timeScale = 0;
        // Mausinteraktion erlauben
        Cursor.lockState = CursorLockMode.Confined;   
    }

    // Es fehlen noch funktionen um die scene neu zu laden und um wieder in lobby zurück zu kehren bei Knopfdruck
    // Überlegung: diese Funktion in ein eigenes Script auszulagern weil diese Funktion entwerder schon da sind wieder verwendet werden könnten unabhängig von welcher ui
    // Die funktionen liegen jz im handleMenu Script
    
}
