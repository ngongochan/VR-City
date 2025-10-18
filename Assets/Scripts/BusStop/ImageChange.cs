using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// change ad or show team credits after x seconds
public class ImageChange : MonoBehaviour
{
    // an array of Image objects, say 10 objects, each object is either a team image or a uni photo
    [SerializeField] Sprite[] imagesCollection;
    //IEnumerator coroutine; no need?
    [SerializeField] Image displayImage;
    [SerializeField] public float imageCyclePeriod = 10f;
    int index = 0;

    void Start()
    {
        if (!displayImage)
        {
            displayImage = GetComponent<Image>();
        }
        if (imagesCollection.Length > 0 && displayImage)
        {
            StartCoroutine(CycleImages());
        }
        else
        {
            Debug.Log("No images available on " + gameObject.name); // 
        }
    }

    IEnumerator CycleImages()
    {
        //if (index < imagesCollection.Length)
        //{
        //    displayImage.sprite = imagesCollection[index];
        //    yield return new WaitForSeconds(imageCyclePeriod);
        //    index += 1;
        //}
        //else
        //{
        //    index = 0;
        //}

        while (true)
        {
            displayImage.sprite = imagesCollection[index];
            yield return new WaitForSeconds(imageCyclePeriod);
            index = Random.Range(0, imagesCollection.Length);
            Debug.Log("Showing images");
        }

    }
}
