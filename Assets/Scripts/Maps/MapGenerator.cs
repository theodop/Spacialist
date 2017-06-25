using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public TextAsset Csv = null;
    public GameObject mapPrefab = null;
    public GameObject tilePrefab = null;
    public GameObject enginePrefab = null;
    public GameObject wallPrefab = null;
    public Light lightPrefab = null;

    [SerializeField]
    public FloatRange lightRandomisation = new FloatRange(0.9f, 1.1f);

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
                    var data = csvCols[j].Trim().Split('|');

                    if (data.Length > 0)
                    {
                        GameObject tile = null;

                        if (data[0] == "1")
                        {
                            tile = Instantiate(tilePrefab);
                            tile.transform.parent = map.transform;
                            tile.transform.position = new Vector3(j, -i, 0);
                        }
                        else if (data[0] == "2")
                        {
                            tile = Instantiate(enginePrefab);
                            tile.transform.parent = map.transform;
                            tile.transform.position = new Vector3(j, -i, -0.5f);
                        }
                    }

                    if (data.Length>1)
                    {
                        string walls = data[1];

                        if (walls.Contains("L"))
                        {
                            GameObject wall = Instantiate(wallPrefab);

                            wall.transform.parent = map.transform;
                            wall.transform.position = new Vector3(j - 0.5f, -i, -0.45f);
                        }

                        if (walls.Contains("T"))
                        {
                            GameObject wall = Instantiate(wallPrefab);

                            wall.transform.parent = map.transform;
                            wall.transform.position = new Vector3(j, -i + 0.5f, -0.45f);
                            wall.transform.rotation = Quaternion.Euler(0, 0, 90);
                        }
                    }

                    if (data.Length>2)
                    {
                        string color = data[2];
                        if (color.Length == 6)
                        {

                            Light light = Instantiate(lightPrefab);
                            light.color = new Color(
                                int.Parse(color.Substring(0, 2), System.Globalization.NumberStyles.HexNumber) / 256f, 
                                int.Parse(color.Substring(2, 2), System.Globalization.NumberStyles.HexNumber) / 256f, 
                                int.Parse(color.Substring(4, 2), System.Globalization.NumberStyles.HexNumber) / 256f);
                            light.transform.parent = map.transform;
                            light.transform.position = new Vector3(j, -i, -0.75f);
                            light.intensity *= lightRandomisation.RandomBetween();
                        }
                    }
                }
            }
        }
    }
}
