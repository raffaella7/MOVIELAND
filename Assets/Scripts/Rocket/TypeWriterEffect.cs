using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class TypeWriterEffect : MonoBehaviour
{
    [SerializeField] public TMP_Text uiText;  // rif al Text dell'UI
    public float delay = 0.1f;  // delay tra una lettera e l'altra

    private string fullText;  // testo completo che vediamo
    private string currentText = "";  // testo che sto vedendo adesso

    void Start()
    {
        fullText = uiText.text; //testo completo

        StartCoroutine(ShowText()); //inizio la corutine per l'effetto
    }

    IEnumerator ShowText()
    {

        for (int i = 0; i <= fullText.Length; i++)  //ciclo dalla prima lettera fino alla lunghezza del testo completo
        {
            currentText = fullText.Substring(0, i); //estraggo una sottostringa del testo completo, ovvero da 0 all'indice i

            uiText.text = currentText;  //aggiorno il testo visualizzato con la sottostringa di quel moemnto

            yield return new WaitForSeconds(delay);     //aspetto per il delay prima di vedere la prossima lettera
        }
        yield return new WaitForSeconds(2f);
        uiText.text = "";



    }


}
