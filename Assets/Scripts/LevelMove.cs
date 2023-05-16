using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMove : MonoBehaviour
{
    public Vector2 CameraChange;
    public Vector3 PlayerChange;
    private CameraMovement cam;
    public bool NecessaryText;
    public string AreaName;
    public GameObject text;
    public Text placeText;

    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cam.minPosition += CameraChange;
            cam.maxPosition += CameraChange;
            other.transform.position += PlayerChange;
            if (NecessaryText)
            {
                StartCoroutine(AreaNameCO());
            }
        }
    }

    private IEnumerator AreaNameCO()
    {
        text.SetActive(true);
        placeText.text = AreaName;
        yield return new WaitForSeconds(4f);
        text.SetActive(false);
    }

}
