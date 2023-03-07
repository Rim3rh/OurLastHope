using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialoge : MonoBehaviour
{
    public TextMeshPro textComponent;
    public string[] lines;
    public int index;
    public float textSpeed;
    int contador1;

    void Start()
    {
         contador1 = 0;
        textComponent.text = string.Empty;
        
    }
    void StartDialoge() {
        index = 0;
        StartCoroutine(TypeLine());

    }
    IEnumerator TypeLine()
    {
        foreach( char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());

        }
        else
        {
            gameObject.SetActive(false);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && contador1 == 0){ 
            contador1++;      
            StartDialoge();
        }
    }
}
