using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;

public class TileManagement : MonoBehaviour {

	public GameObject[] tileList = new GameObject[4];
	public byte[] regionImage;

	private Color grassColor = new Color(0,255,0);
	private Color forestColor = new Color(0.2f,0.4f,0);
	private Color sandColor = new Color(0.95f,0.9f,0);
	private Color randomColor = new Color(0f,0f,1f);

	public int regionPositionX;
	public int regionPositionY;

	public float xOrg = 25;
	public float yOrg = 25;
	public float scale = 3.5F;
	private Texture2D regionMap = new Texture2D(1000,1000);
	private Color[] pix;
	private Renderer rend;

	void Start ()
	{
		rend = GetComponent<Renderer>();
		pix = new Color[regionMap.width * regionMap.height];

		xOrg = (int)Random.Range(1,100);
		yOrg = (int)Random.Range(1,100);
		scale = Random.Range(2,4);
		float y = 0.0F;
		while (y < regionMap.height) {
			float x = 0.0F;
			while (x < regionMap.width) {
				float xCoord = xOrg + x / regionMap.width * scale;
				float yCoord = yOrg + y / regionMap.height * scale;
				float sample = Mathf.PerlinNoise(xCoord, yCoord);
				if(sample < 0.2f)
				{
					pix[(int)(y * regionMap.width + x)] = randomColor;

				}
				else if(sample < 0.5f)
				{
					pix[(int)(y * regionMap.width + x)] = grassColor;
				}
				else if(sample < 0.6f)
				{
					pix[(int)(y * regionMap.width + x)] = sandColor;

				}
				else if (sample < 0.8f)
				{
					pix[(int)(y * regionMap.width + x)] = forestColor;
				}
				x++;
			}
			y++;
		}
		regionMap.filterMode = FilterMode.Point;
		regionMap.SetPixels(pix);
		regionMap.Apply();
		rend.material.mainTexture = regionMap;
		byte[] bytes = regionMap.EncodeToPNG();
		regionImage = bytes;
		File.WriteAllBytes(@Application.streamingAssetsPath + "/Regions/" + gameObject.name + ".jpg", bytes);
	}
}