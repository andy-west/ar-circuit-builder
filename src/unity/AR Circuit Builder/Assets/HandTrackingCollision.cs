using System.Collections.Generic;
using UnityEngine;

public class HandTrackingCollision : MonoBehaviour
{
    public Material GrayMaterial;
    public Material GreenMaterial;

    private List<GameObject> _parts;
    private int _partIndex = 0;

    protected void Start()
    {
        _parts = new List<GameObject>
        {
            GameObject.Find("batteries"),
            GameObject.Find("resistor"),
            GameObject.Find("led"),
            GameObject.Find("switch")
        };

        foreach (var part in _parts)
        {
            part.SetActive(false);
        }
    }

    protected void OnTriggerEnter()
    {
        gameObject.GetComponent<MeshRenderer>().material = GreenMaterial;

        if (_partIndex < _parts.Count)
        {
            _parts[_partIndex].SetActive(true);
            _partIndex++;
        }
        else
        {
            foreach (var part in _parts)
            {
                part.SetActive(false);
            }

            _partIndex = 0;
        }
    }

    protected void OnTriggerExit()
    {
        gameObject.GetComponent<MeshRenderer>().material = GrayMaterial;
    }
}
