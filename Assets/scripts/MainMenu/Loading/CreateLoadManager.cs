using HillClimb3d.UI.Loading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HillClimb3d.UI.Loading
{
    public class CreateLoadManager : MonoBehaviour
    {
        [SerializeField]
        GameObject _loadManagerPrefab;
        private void Awake()
        {
            if (LoadManager.Instance == null)
            {
                if (_loadManagerPrefab == null)
                    _loadManagerPrefab = Resources.Load("LoaderManager") as GameObject;

                DontDestroyOnLoad(Instantiate(_loadManagerPrefab));
            }
        }
    }
}
