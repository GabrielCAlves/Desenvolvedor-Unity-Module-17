using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollectableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public TextMeshProUGUI textMeshProUGUI;

    private void Awake()
    {
        textMeshProUGUI = GameObject.Find("Text_(TMP)_Contabilizador").GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        gameObject.SetActive(false);
        OnCollect();
    }

    protected virtual void OnCollect()
    {

    }
}
