using System.Collections;
using UnityEngine;
using UnityEngine.UI;

    [RequireComponent(typeof(Text))]
    public class FpsDisplay : MonoBehaviour
    {
        [SerializeField] private float updateFrequency = 1f;
        [SerializeField] private Text fpsText;

        void Awake ()
        {
            fpsText = GetComponent<Text>();
        }

        void Start ()
        {
            StartCoroutine(UpdateCounter());
        }

        IEnumerator UpdateCounter ()
        {
            var waitForDelay = new WaitForSeconds(updateFrequency);

            while (true)
            {
                var lastFrameCount = Time.frameCount;
                var lastTime = Time.realtimeSinceStartup;

                yield return waitForDelay;

                var timeDelta = Time.realtimeSinceStartup - lastTime;
                var frameDelta = Time.frameCount - lastFrameCount;

                fpsText.text = string.Format("{0:0.} FPS", frameDelta / timeDelta);
            }
        }
    }
