using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeakPeople : MonoBehaviour
{
    [HideInInspector] [SerializeField] GameObject dialogCloudFirst;
    [HideInInspector] [SerializeField] GameObject dialogCloudSeconde;
    [HideInInspector] [SerializeField] Text firstSpeakerText;
    [HideInInspector] [SerializeField] Text secondeSpeakerText;
    [SerializeField] float speedSpeak = 1;
    [SerializeField] List<Dialogue> dialogues;
    int queue = 0;
    private void Awake()
    {
        dialogCloudFirst.SetActive(false);
        dialogCloudSeconde.SetActive(false);
        StartCoroutine(Speak());
    }
    IEnumerator Speak()
    {
        while (true)
        {


            switch (dialogues[queue].speaker)
            {
                case Dialogue.Speakers.First:
                    dialogCloudFirst.SetActive(true);
                    firstSpeakerText.text = dialogues[queue].text;
                    break;
                case Dialogue.Speakers.Seconde:
                    dialogCloudSeconde.SetActive(true);
                    secondeSpeakerText.text = dialogues[queue].text;
                    break;
                default:
                    break;
            }
            if (queue < dialogues.Count - 1)
            {
                queue++;
            }
            else
            {
                queue = 0;
            }

            yield return new WaitForSeconds(speedSpeak);
            dialogCloudFirst.SetActive(false);
            dialogCloudSeconde.SetActive(false);
        }
    }

}
[System.Serializable]
public struct Dialogue
{
    public enum Speakers { First = 0, Seconde = 1 }
    public string text;
    public Speakers speaker;
}