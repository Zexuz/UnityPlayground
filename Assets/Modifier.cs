using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;

public class Modifier : MonoBehaviour
{
    public GameObject GameObjectPrefab;


    public void PrintMessage(string message)
    {
        Instantiate(GameObjectPrefab, GameObjectPrefab.transform.position, Quaternion.identity);
    }
}