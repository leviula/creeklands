using System.Collections.Generic;
using UnityEngine;

public class ARObjectManager : MonoBehaviour
{
    private List<GameObject> currentObjects = new List<GameObject>();

    public void ShowPrefabs(ARObjectData[] objects, Transform spawnPoint)
    {
        HidePrefabs();

        if (objects == null || spawnPoint == null)
            return;

        foreach (ARObjectData objectData in objects)
        {
            if (objectData.prefab == null)
                continue;

            GameObject obj = Instantiate(
                objectData.prefab,
                spawnPoint
            );

            obj.transform.localPosition = objectData.localPosition;
            obj.transform.localEulerAngles = objectData.localRotation;
            obj.transform.localScale = objectData.localScale;

            currentObjects.Add(obj);

            Debug.Log("Spawned: " + obj.name);
        }
    }

    public void HidePrefabs()
    {
        foreach (GameObject obj in currentObjects)
        {
            if (obj != null)
                Destroy(obj);
        }

        currentObjects.Clear();
    }
}