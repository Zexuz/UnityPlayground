using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class ToogleArCam : MonoBehaviour, IInputClickHandler
{
    public GameObject ARCamera;
    public TextMesh Text;

    // Use this for initialization
    void Start()
    {
        UpdateText();
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        ARCamera.SetActive(!ARCamera.activeSelf);
        UpdateText();
    }

    private void UpdateText()
    {
        Text.text = string.Format("AR STATUS: {0}", ARCamera.activeSelf ? "on" : "off");
    }
}