using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public TextAsset Csv = null;
    public GameObject mapPrefab = null;
    public GameObject tilePrefab = null;
    public GameObject enginePrefab = null;

	// Use this for initialization
	void Awake () {
        Generate();
	}
    
    void Generate()
    {
        if (Csv != null)
        {
            var map = Instantiate(mapPrefab);
            var csvRows = Csv.text.Split('\n');

            for (int i=0; i<csvRows.Length; i++)
            {
                var csvCols = csvRows[i].Split(',');

                for (int j=0; j<csvCols.Length; j++)
                {
                    var data = csvCols[j].Trim();
                    GameObject tile = null;

                    if (data == "1")
                    {
                        tile = Instantiate(tilePrefab);
                        
                    }
                    if (data == "2")
                    {
                        tile = Instantiate(enginePrefab); 
                    }

                    if (tile!= null)
                    {
                        tile.transform.parent = map.transform;
                        tile.transform.position = new Vector3(j, -i, 0);
                    }

                }
            }
        }
    }
}
