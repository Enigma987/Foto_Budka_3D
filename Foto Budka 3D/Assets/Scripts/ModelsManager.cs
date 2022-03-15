using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModelsManager : MonoBehaviour
{
    public List<GameObject> models;
    private int actualModel = 0;

    public TextMeshProUGUI actualModelText;

    // Start is called before the first frame update
    void Start()
    {
        //Tu bêdzie pobieranie modeli z pliku

        ShowModel();
    }

    public void ShowModel()
    {
        foreach(GameObject model in models)
            model.SetActive(false);

        models[actualModel].SetActive(true);

        actualModelText.text = actualModel.ToString();
    }

    public void BackButton()
    {
        if (actualModel == 0)
            actualModel = models.Count - 1;
        else
            actualModel -= 1;

        ShowModel();
    }

    public void NextButton()
    {
        if (actualModel == models.Count - 1)
            actualModel = 0;
        else
            actualModel += 1;

        ShowModel();
    }

    public void ZoomButtons(bool zoomIn)
    {
        if(zoomIn)
            models[actualModel].transform.position = new Vector3(models[actualModel].transform.position.x, models[actualModel].transform.position.y, models[actualModel].transform.position.z - 1);
        else
            models[actualModel].transform.position = new Vector3(models[actualModel].transform.position.x, models[actualModel].transform.position.y, models[actualModel].transform.position.z + 1);
    }
}
