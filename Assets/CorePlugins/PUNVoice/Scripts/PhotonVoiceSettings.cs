﻿using UnityEngine;
using ExitGames.Client.Photon.Voice;

/// <summary>
/// Collection of Photon Voice settings. Add single instance to the scene and set values in inspector.
/// Will be created automatically on application start otherwise.
/// </summary>
[DisallowMultipleComponent]
public class PhotonVoiceSettings : MonoBehaviour
{

    /// Follow PUN room status (connect, join, rejoin).
    public bool AutoConnect = true;             // set in inspector

    /// Disconnect voice client as PUN client dosconnects.
    public bool AutoDisconnect = false;         // set in inspector

    /// Start recording and transmit as soon as joined to the room.
    public bool AutoTransmit = true;            // set in inspector

    /// Outgoing audio stream sampling rate (applied per every recoder instance).
    public POpusCodec.Enums.SamplingRate SamplingRate = POpusCodec.Enums.SamplingRate.Sampling24000;     // set in inspector

    /// Outgoing audio stream encoder delay (buffer size in terms of time; applied per every recoder instance).
    public OpusCodec.FrameDuration FrameDuration = OpusCodec.FrameDuration.Frame20ms;   // set in inspector

    /// Outgoing audio stream bitrate (applied per every recoder instance).
    public int Bitrate = 30000;               // set in inspector

    /// Enable voice detection (applied per every recoder instance).
    public bool VoiceDetection = false;                 // set in inspector

    /// Voice detection threshold (applied per every recoder instance).
    public float VoiceDetectionThreshold = 0.01f;       // set in inspector

    /// Remote audio stream playback delay to compensate packets latency variations (applied per every speaker instance). Try 100 - 200 if sound is choppy.
    public int PlayDelayMs = 200;                       // set in inspector

    public enum MicAudioSourceType
    {
        Unity,
        Photon
    }

    /// Default microphone type;
    public MicAudioSourceType MicrophoneType;
    /// Lost frames simulation ratio.
    public int DebugLostPercent = 0;                    // set in inspector

    /// Log debug info.
    public bool DebugInfo = false;                    // set in inspector

//    public string AppId = "<app-id>";
//    public string AppVersion = "1.0";


    private static PhotonVoiceSettings instance;
    private static object instanceLock = new object();

    /// <summary>
    /// Get current settings.
    /// </summary>
    public static PhotonVoiceSettings Instance { 
        get 
        {
            if (instance == null)
            {
                instance = PhotonVoiceNetwork.instance.gameObject.AddComponent<PhotonVoiceSettings>();
            }
            return instance; 
        }
        private set
        {
            if (instance != value)
            {
                if (instance != null && value != null)
                {
                    Debug.LogErrorFormat(value, "PUNVoice: PhotonVoiceSettings instance already set, extra instance ignored.");
                    return;
                }
                instance = value;
            }
        }
    }

    // for settings put in scene in editor
    void Awake()
    {
        lock (instanceLock)
        {
            Instance = this;
        }
    }
}