using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

    public GameObject Prefab;
    [Range(0,6)]
    public int NumPairs;

	// Use this for initialization
	void Start () {
        List<ChangeColor> CubeList = new List<ChangeColor>();
        for (int x = 0; x < NumPairs; x++) {
            for (int y = 0; y < 2; y++) {
                GameObject NewCube = (GameObject) Instantiate(Prefab, new Vector3 (2 * x, 2 * y,0f), Quaternion.identity);
                CubeList.Add(NewCube.GetComponentInChildren<ChangeColor>());
            }
        }
        for (int i = 0; i < NumPairs; i++) {
            float Hue = 1.0f / NumPairs * i;
            Color NotSoRandomColor = Color.HSVToRGB(Hue, 1, 1);
            for (int j = 0; j < 2; j++) {
                ChangeColor CubeToChange = CubeList[Random.Range(0, CubeList.Count)];
                CubeToChange.TrueColor = NotSoRandomColor;
                CubeList.Remove(CubeToChange);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
