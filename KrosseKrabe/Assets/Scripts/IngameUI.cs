using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IngameUI : MonoBehaviour
{
// 1. Initialisierungen
    // Instruction (Text)
    // [SerializeField] private TextMeshProUGUI instructionLabel; // Immoment nicht vorhanden

    // Error Count UI (Counter)
    [SerializeField] private TextMeshProUGUI errorCountLabel = null;

    // Help Count UI (Counter)
    [SerializeField] private TextMeshProUGUI helpCountLabel = null;


    // Help and Error Text UI (Text)
    public GameObject uiElement;
    [SerializeField] private TextMeshProUGUI errorLabel;
    [SerializeField] private float errorDisplayTime = 5.0f;
    [SerializeField] private TextMeshProUGUI helpLabel;
    [SerializeField] private float helpDisplayTime = 5.0f;

    // Result / Score (when trainig finished) 
    // [SerializeField] private string totalErrorPrefix = "Total Errors: "; // Immoment nicht vorhanden
    // [SerializeField] private string totalHelpCountPrefix = "Total Help: "; // Immoment nicht vorhanden
    // [SerializeField] private TextMeshProUGUI totalErrorCountLabel = null; // Immoment nicht vorhanden
    // [SerializeField] private TextMeshProUGUI totalHelpCountLabel = null; // Immoment nicht vorhanden

// 2. Funktionen 
    private void  Awake()
    {
        //instructionLabel.SetText("");
        errorLabel.SetText("");
        helpLabel.SetText("");
        helpCountLabel.SetText("0");
        errorCountLabel.SetText("0");
    }
    void Start(){
        uiElement.SetActive(false);
    }
    void Update(){}

    // 2.1 handle Help and Error Text + Counter
    
    private IEnumerator DisplayForDuration(TextMeshProUGUI label, string msg, float duration)
        {
        uiElement.SetActive(true);
        label.text = msg;
            yield return new WaitForSeconds(duration);
            label.text = "";
            uiElement.SetActive(false);
        }
    public void DisplayHelp(string helpMsg, int helpCount)
        {
            StopHelpAndErrorDisplay();
            helpCountLabel.text = helpCount + "";
            StartCoroutine(DisplayForDuration(helpLabel, helpMsg, helpDisplayTime));
        }

        public void DisplayError(string errorMsg, int errorCount)
        {
            StopHelpAndErrorDisplay();
            errorCountLabel.text = errorCount + "";
            StartCoroutine(DisplayForDuration(errorLabel, errorMsg, errorDisplayTime));
        }
        public void StopHelpAndErrorDisplay()
        {
            StopAllCoroutines();
            helpLabel.SetText("");
            errorLabel.SetText("");
        }

    // 2.2 handle Instruction // Immoment nicht vorhanden
    /*
    public void DisplayInstruction(string instruction)
        {
            StopHelpAndErrorDisplay();
            instructionLabel.SetText(instruction);
        } 
    */

    // 2.3 handle Result / Score 
    /*
    public void SetResultsPanel(int totalErrorCount, int totalHelpCount)
        {
            totalErrorCountLabel.SetText(totalErrorPrefix + totalErrorCount);
            totalHelpCountLabel.SetText(totalHelpCountPrefix + totalHelpCount);
        }
    */
}
