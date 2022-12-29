using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecordLabel : MonoBehaviour
{
    [SerializeField]
    private int level;

    private TextMeshPro label;

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        if(level != -1 && GameManager.Instance.RecordsManager.RecordsCollection.records.Length >= level)
        {
            label.text = "Record " + GameManager.Instance.RecordsManager.RecordsCollection.records[level - 1];
        }
    }
}
