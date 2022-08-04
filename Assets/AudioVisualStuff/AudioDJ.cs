using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnimportantStuff
{
    public class AudioDJ : MonoBehaviour
    {

        public AudioClip[] Clips = new AudioClip[3];
        AudioSource[] sources;
        // Start is called before the first frame update
        void Start()
        {
            sources = new AudioSource[Clips.Length];
            for (int x = 0; x < Clips.Length; x++)
            {
                sources[x] = new GameObject("Source " + x).AddComponent<AudioSource>() as AudioSource;
                sources[x].clip = Clips[x];
                sources[x].enabled = false;
                sources[x].loop = true;
            }
            sources[0].enabled = true;
        }

        // Update is called once per frame
        void Update()
        {


        }


        private void OnGUI()
        {
            if (GUI.Button(new Rect(50, 50, 100, 100), "Activate clip 2"))
            {
                StartCoroutine("ActivateClip", 1);
            }
            if (GUI.Button(new Rect(50, 130, 100, 100), "Activate clip 3"))
            {
                StartCoroutine("ActivateClip", 2);
            }
            GUI.Label(new Rect(160, 50, 100, 100), sources[0].time.ToString());

        }
        IEnumerator ActivateClip(int Index)
        {
            if (Index == 0)
            {
                Debug.Log("Breaking off");
                yield break;
                
            }
            while (!sources[Index].enabled)
            {
                Debug.Log("Activating source number " + (Index + 1) + "....");
                if (sources[0].time < 1)
                    sources[Index].enabled = true;
                yield return null;
            }
            Debug.Log("Source " + (Index + 1) + " activation confirmed");
        }
    }
}
