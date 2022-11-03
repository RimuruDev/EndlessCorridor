using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RimuruDev
{
    public sealed class SceneSettings : MonoBehaviour
    {
        private void Awake()
        {
            Time.timeScale = 1f;

            QualitySettings.vSyncCount = 0;

            Application.targetFrameRate = 60;
        }
    }
}
