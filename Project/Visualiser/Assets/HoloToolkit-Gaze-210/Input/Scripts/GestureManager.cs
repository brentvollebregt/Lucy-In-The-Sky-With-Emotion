using UnityEngine;
using UnityEngine.VR.WSA.Input;
using System.Linq;

namespace Academy.HoloToolkit.Unity
{
    /// <summary>
    /// GestureManager contains event handlers for subscribed gestures.
    /// </summary>
    public class GestureManager : MonoBehaviour
    {
        private GestureRecognizer gestureRecognizer;

        void Start()
        {
            gestureRecognizer = new GestureRecognizer();
            gestureRecognizer.SetRecognizableGestures(GestureSettings.Tap);
            
            gestureRecognizer.TappedEvent += (source, tapCount, ray) =>
            {
                GameObject focusedObject = InteractibleManager.Instance.FocusedGameObject;

                if (focusedObject != null && GameObject.FindGameObjectsWithTag("Placeable").Contains(focusedObject))
                {
                    focusedObject.SendMessageUpwards("Move");          
                }
                else
                    SendMessageUpwards("MakeBall");
            };

            gestureRecognizer.StartCapturingGestures();
        }

        void OnDestroy()
        {
            gestureRecognizer.StopCapturingGestures();
        }
    }
}