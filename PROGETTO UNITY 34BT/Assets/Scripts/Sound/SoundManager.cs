using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace UnityCore
{
    namespace Audio
    {
        public class SoundManager : MonoBehaviour
        {


            public static SoundManager instance;


            public bool debug;
            public AudioTrack[] tracks;


            private Hashtable AudioTable; // relazione tra tipi di audio e traccie audio
            private Hashtable FunctionTable;


            [System.Serializable]
            public class AudioObject
            {
                public AudioType type;
                public AudioClip clip;
            }

            [System.Serializable]
            public class AudioTrack
            {
                public AudioSource source;
                public AudioObject[] audio;
            }

            private class AudioFunction
            {
                public AudioAction action;
                public AudioType type;

                public AudioFunction(AudioAction _action, AudioType _type)
                {
                    action = _action;
                    type = _type;
                }
            }

            private enum AudioAction
            {
                START,
                STOP,
                RESTART,

            }

            #region Metodi Unity

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            private void Awake()
            {
                if (!instance)
                {
                    Configure();
                }
            }


            private void OnDisable()
            {
                Dispose();
            }
            #endregion

            #region Metodi Pubblici

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            public void PlayAudio(AudioType type)
            {
                AddFunction(new AudioFunction(AudioAction.START, type));
            }
            public void StopAudio(AudioType type)
            {
                AddFunction(new AudioFunction(AudioAction.STOP, type));

            }
            public void RestartAudio(AudioType type)
            {
                AddFunction(new AudioFunction(AudioAction.RESTART, type));

            }


            #endregion

            #region Metodi Privati

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            private void Configure()
            {
                instance = this;

                AudioTable = new Hashtable();
                FunctionTable = new Hashtable();
                GenerateAudioTable();
            }

            private void Dispose()
            {
                foreach (DictionaryEntry _entry in FunctionTable)
                {
                    IEnumerator _function = (IEnumerator)_entry.Value;
                    StopCoroutine(_function);
                }
            }

            private void GenerateAudioTable()
            {
                foreach (AudioTrack track in tracks)
                {
                    foreach (AudioObject Aobj in track.audio)
                    {
                        // non duplicare keys
                        if (AudioTable.ContainsKey(Aobj.type))
                        {
                            LogWarning("Stai cercando di registrare l'audio [" + Aobj.type + "] che è già stato registrato");
                        }
                        else
                        {
                            AudioTable.Add(Aobj.type, track);
                            Log("Registrazione audio in corso [" + Aobj.type + "].");
                        }
                    }
                }
            }

            private void Log(string _message)
            {
                if (!debug)
                {
                    return;
                }

                Debug.Log("[Audio Controller]: " + _message);
            }

            private void LogWarning(string _message)
            {
                if (!debug)
                {
                    return;
                }

                Debug.LogWarning("[Audio Controller]: " + _message);
            }


            private IEnumerator RunAudioFunction(AudioFunction _function)
            {
                AudioTrack track = (AudioTrack)AudioTable[_function.type];
                track.source.clip = GetAudioClipFromAudioTrack(_function.type, track);

                switch (_function.action)
                {
                    case AudioAction.START:

                        track.source.Play();

                        break;

                    case AudioAction.STOP:

                        track.source.Stop();

                        break;

                    case AudioAction.RESTART:

                        track.source.Stop();
                        track.source.Play();

                        break;

                }

                FunctionTable.Remove(_function.type);

                Log("Function count: " + FunctionTable.Count);

                yield return null;

            }

            public AudioClip GetAudioClipFromAudioTrack(AudioType type, AudioTrack track)
            {
                foreach (AudioObject _obj in track.audio)
                {
                    if (_obj.type == type)
                    {
                        return _obj.clip;
                    }
                }
                return null;
            }

            private void AddFunction(AudioFunction _function)
            {
                // rimozione funzione conflittuale

                RemoveConflictingFunctions(_function.type);

                // avvio funzione
                IEnumerator FunctionRunner = RunAudioFunction(_function);
                FunctionTable.Add(_function.type, FunctionRunner);
                StartCoroutine(FunctionRunner);
                Log("Starting function on [" + _function.type + "] with operation" + _function.action);


            }

            private void RemoveFunction(AudioType _type)
            {
                if (!FunctionTable.ContainsKey(_type))
                {
                    LogWarning("Trying to stop a job [" + _type + "] that is not running");
                    return;
                }

                IEnumerator runningfuntion = (IEnumerator)FunctionTable[_type];
                StopCoroutine(runningfuntion);
                FunctionTable.Remove(_type);
            }


            private void RemoveConflictingFunctions(AudioType _type)
            {
                if (FunctionTable.ContainsKey(_type))
                {
                    RemoveFunction(_type);
                }

                AudioType _conflictAudio = AudioType.None;

                foreach (DictionaryEntry _entry in FunctionTable)
                {
                    AudioType _audioType = (AudioType)_entry.Key;
                    AudioTrack _audiotrackinuse = (AudioTrack)AudioTable[_audioType];
                    AudioTrack _audiotrackneeded = (AudioTrack)AudioTable[_type];
                    if (_audiotrackneeded.source == _audiotrackinuse.source)
                    {
                        //conflict
                        _conflictAudio = _audioType;
                    }
                }

                if (_conflictAudio != AudioType.None)
                {
                    RemoveFunction(_conflictAudio);
                }
            }

            #endregion




        }
    }
}

