using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UnityCore
{
    namespace Audio
    {
        public class AudioInput : MonoBehaviour
        {
            public SoundManager soundManager;

            private void Start()
            {
                soundManager.PlayAudio(AudioType.AMB_01);
            }

            private void Update()
            {
                if (Input.GetKeyDown(KeyCode.T))
                {
                    soundManager.PlayAudio(AudioType.AMB_01);
                }



            }
        }
    }

}

