using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;

public class TextureRandom : MonoBehaviour
{   
    public GameObject random_conA;
    public GameObject random_conX;
    public GameObject random_conB;
    public GameObject random_conP;
    public GameObject random_con8;
    public GameObject random_conSpace;


    // Start is called before the first frame update
    void Start()
    {
        Texture2D[] textures = Resources.LoadAll<Texture2D>("Textures");
        var list = new List<int> {0, 1, 2, 3, 4, 5};
        list = list.OrderBy(i => Random.value).ToList();
        // Texture2D texture = textures.OrderBy(i => Random.value).ToList();
        // Texture2D texture = textures[Random.Range(0, textures.Length)];
        // gameObject.GetComponent<RawImage>().texture = texture;

        random_conA.GetComponent<RawImage>().texture       = textures[list[0]];
        random_conX.GetComponent<RawImage>().texture       = textures[list[1]];
        random_conB.GetComponent<RawImage>().texture       = textures[list[2]];
        random_conP.GetComponent<RawImage>().texture       = textures[list[3]];
        random_con8.GetComponent<RawImage>().texture       = textures[list[4]];
        random_conSpace.GetComponent<RawImage>().texture   = textures[list[5]];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}