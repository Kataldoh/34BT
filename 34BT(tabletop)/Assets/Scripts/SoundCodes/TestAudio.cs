using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UnityCore
{
    namespace Audio
    {
        public class TestAudio : MonoBehaviour
        {
            public SoundManager soundManager;


            private void Update()
            {
                if (Input.GetKeyDown(KeyCode.T))
                {
                    soundManager.PlayAudio(AudioType.ST_01);
                }
                if (Input.GetKeyDown(KeyCode.G))
                {
                    soundManager.StopAudio(AudioType.ST_01);
                }
                if (Input.GetKeyDown(KeyCode.B))
                {
                    soundManager.RestartAudio(AudioType.ST_01);
                }
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    soundManager.PlayAudio(AudioType.SFX_01);
                }
                if (Input.GetKeyDown(KeyCode.H))
                {
                    soundManager.StopAudio(AudioType.SFX_01);
                }
                if (Input.GetKeyDown(KeyCode.N))
                {
                    soundManager.RestartAudio(AudioType.SFX_01);
                }
            }
        }

    }
}
