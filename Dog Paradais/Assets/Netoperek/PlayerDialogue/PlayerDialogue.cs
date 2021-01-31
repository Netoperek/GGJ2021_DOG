using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDialogue : MonoBehaviour
{
    [Header("Ikony")]
    [SerializeField] List<Sprite> icons;
    [SerializeField] float speedDialogue;
    [HideInInspector] [SerializeField] Image icon;
    [Header("Chumrka")]
    [HideInInspector] [SerializeField] Image dialogueImage;
    [HideInInspector] [SerializeField] GameObject canvas;
    [SerializeField] float speedFade;
    Color color;
    [Tooltip("Szybkość pojawiania się")] [SerializeField] float fade = 0f;
    int index = 0;
    bool isVisible = false;

    private void Awake()
    {
        
        color = new Color(0f, 0f, 0f, fade);
        icon.enabled = false;
        canvas.SetActive(true);
        StartCoroutine(OpenDialogue());
    }
    IEnumerator Dialogues()
    {
        while (true)
        {
            
                if (index < icons.Count)
                {
                    Debug.Log(icons.Count);
                    icon.sprite = icons[index];
                    index++;
                }
                else
                {
                    canvas.SetActive(false);
                    yield break;
                }
            
            yield return new WaitForSeconds(speedDialogue);
            
        }
    }
    IEnumerator OpenDialogue()
    {
        while (true)
        {
           

            yield return new WaitForSeconds(speedFade);
            if (1f >= dialogueImage.color.a)
            {
                dialogueImage.color += color;
            }
            else
            {
                icon.enabled = true;
                StartCoroutine(Dialogues());
                yield break;
            }

        }
    }


}
