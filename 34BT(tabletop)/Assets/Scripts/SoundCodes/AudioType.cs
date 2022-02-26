using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace UnityCore
{
    namespace Audio
    {
        public enum AudioType //In questo enum si possono definire tutti i tipi di audio 

                              //Ogni tipo di audio può succesivamente essere passato allo script del SoundManager

                              
        {
            ST_01, //ST sta per soundtrack
            AMB_01, //AMB sta per ambience
            SFX_01, // SFX sta per sound effect
            SFX_02,
            None,



        }

    }
}
