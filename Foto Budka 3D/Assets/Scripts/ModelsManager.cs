using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelsManager : MonoBehaviour
{
    public List<GameObject> models;
    private int actualModel;

    // Start is called before the first frame update
    void Start()
    {
        //Tu bêdzie pobieranie modeli z pliku
        models[0].SetActive(true);
        actualModel = 0;
    }

    public void ShowModel(int _actual)
    {
        foreach(GameObject model in models)
        {
            model.SetActive(false);
        }

        models[_actual].SetActive(true);
    }

    public void BackButton()
    {
        if (actualModel == 0)
            actualModel = models.Count - 1;
        else
            actualModel -= 1;

        ShowModel(actualModel);
    }

    public void NextButton()
    {
        if (actualModel == models.Count - 1)
            actualModel = 0;
        else
            actualModel += 1;

        ShowModel(actualModel);
    }

    public void ZoomInButton(bool zoomIn)
    {
        if(zoomIn)
            models[actualModel].transform.position = new Vector3(models[actualModel].transform.position.x, models[actualModel].transform.position.y, models[actualModel].transform.position.z - 1);
        else
            models[actualModel].transform.position = new Vector3(models[actualModel].transform.position.x, models[actualModel].transform.position.y, models[actualModel].transform.position.z + 1);
    }
}
