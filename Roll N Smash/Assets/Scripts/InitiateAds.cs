using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InitiateAds : MonoBehaviour
{
    private string _gameID;
    [SerializeField] string _iOSGameID;
    [SerializeField] string _androidGameID;
    [SerializeField] bool _testMode;

    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            _gameID = _androidGameID;
        }
        if(Application.platform == RuntimePlatform.IPhonePlayer)
        {
            _gameID = _iOSGameID;
        }
        else
        {
            _gameID = _androidGameID;
        }
        Advertisement.Initialize(_gameID, _testMode);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Advertisement.Show("Rewarded_Android");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Advertisement.Show("Rewarded_iOS");
        }
    }
}
