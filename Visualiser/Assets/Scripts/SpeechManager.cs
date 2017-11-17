using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechManager : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer = null;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    // Use this for initialization
    void Start()
    {
        keywords.Add("Reset Speaker", () =>
        {
            // Call the OnReset method on every descendant object.
            this.BroadcastMessage("ResetSpeaker");
        });

        keywords.Add("Reset Line", () =>
        {
            // Call the OnReset method on every descendant object.
            this.BroadcastMessage("ResetLine");
        });

        keywords.Add("Toggle Mesh", () =>
        {
            GameSettings.ToggleMesh();
        });

        keywords.Add("Boom", () =>
        {
            this.BroadcastMessage("OnBoom");
        });

        // Tell the KeywordRecognizer about our keywords.
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        // Register a callback for the KeywordRecognizer and start recognizing!
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }
}