using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BasketInteraction : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public GameObject FlowerPrfab;
    public Transform flowerPosition;
    int count;
    bool isEntered;
    float newY;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Deb") & !isEntered)
        {
           // GetComponent<MeshRenderer>().material.color = Color.red;
            count++;
            textMesh.text = count.ToString();
            Destroy(other.gameObject);

            //instantiate flowers
            newY++;
            GameObject newApple = Instantiate(FlowerPrfab);
            newApple.transform.parent = flowerPosition;
            newApple.transform.localPosition = new Vector3(0, newY, 0);
            isEntered = true;
            StartCoroutine(SwitchBool(2.0f));
        }
    }

    IEnumerator SwitchBool(float time)
    {
        yield return new WaitForSeconds(time);
        isEntered = false;
    }
}