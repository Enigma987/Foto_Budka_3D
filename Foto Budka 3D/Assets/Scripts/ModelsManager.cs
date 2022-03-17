using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class ModelsManager : MonoBehaviour
{
    public List<GameObject> listOfModels;
    private int actualModelNumber = 0;

    public GameObject UICanvas;
    public TextMeshProUGUI actualModelText;

    void Start()
    {
       LoadModel();

       ShowModel();
    }

    //Funkcja do wczytywania modeli z folderu Assets/Resources/Input
    public void LoadModel()
    {
        GameObject loadModel;
        GameObject readyModel;

        DirectoryInfo dir = new DirectoryInfo("Assets/Resources/Input");
        FileInfo[] info = dir.GetFiles("*.obj");
        string modelPath;


        foreach (var e in info)
        {
            modelPath = "Input/" + e.Name.Remove(e.Name.Length - 4);
            loadModel = Resources.Load(modelPath) as GameObject;

            readyModel = Instantiate(loadModel);
            readyModel.AddComponent<ModelTransform>();

            listOfModels.Add(readyModel);
        }
    }

    //Do wyœwietlania danego modelu na ekranie
    public void ShowModel()
    {
        if (listOfModels.Count != 0)
        {
            foreach (GameObject model in listOfModels)
                model.SetActive(false);

            listOfModels[actualModelNumber].SetActive(true);

            actualModelText.text = (actualModelNumber + 1).ToString();
        }
        else
            Debug.Log("Pusta lista - brak modeli");
    }


    public void BackButton()
    {
        if (actualModelNumber == 0)
            actualModelNumber = listOfModels.Count - 1;
        else
            actualModelNumber -= 1;

        ShowModel();
    }

    public void NextButton()
    {
        if (actualModelNumber == listOfModels.Count - 1)
            actualModelNumber = 0;
        else
            actualModelNumber += 1;

        ShowModel();
    }

    public void ZoomButtons(bool zoomIn)
    {
        if (zoomIn)
            listOfModels[actualModelNumber].transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        else
            listOfModels[actualModelNumber].transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
    }

    public void ScreenshotButton()
    {
        var folder = Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures) + "/Output");

        StartCoroutine(TakeScreenshot());
    }

    //Wy³¹czenie UI podczas robienia screenshotu
    public IEnumerator TakeScreenshot()
    {
        yield return null;
        UICanvas.SetActive(false);

        yield return new WaitForEndOfFrame();

        ScreenCapture.CaptureScreenshot(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures) + "/Output/" + System.DateTime.Now.ToString("dd_MM_yyy HH_mm_ss") + ".png");

        UICanvas.SetActive(true);
    }
}
