namespace Mapbox.Unity.Location
{
    // This uses LocationArrayEditorLocationProvider as a basis, with
    // modifications to work in Windows executables, too.  
    //
    // Look at DeviceLocationProvider for working with device locations.
    //
    // The device location (whether pulled from the device or the inspector)
    // represents the drop position.  Have a method to move the player to the
    // drop position.

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System;
    using Mapbox.Unity.Utilities;
    using Mapbox.Utils;

    public class FinalLocationProvider : AbstractLocationProvider
    {
        [SerializeField]
        [Geocode]
        string _initialDropLocation;

        [SerializeField]
        [Range(0, 359)]
        float _heading;

        [SerializeField]
        protected int _accuracy;

        [SerializeField]
        bool _autoFireEvent;

        [SerializeField]
        float _updateInterval;

        [SerializeField]
        bool _sendEvent;

        WaitForSeconds _wait = new WaitForSeconds(0);

        private Vector2d _dropLocation;
        private Vector2d _playerLocation;
        private bool goToDropLocation = true;

        public Vector2d PlayerLocation => _playerLocation;

        public Vector2d DropLocation => _dropLocation;

        public float Heading
        {
            get => _heading;
            set => _heading = value;
        }

        // Call to teleport the player to a new location
        public void SetLatLong(string latitudeLongitude)
        {
            _playerLocation = Conversions.StringToLatLon(latitudeLongitude);
        }

        public void BackToDropLocation()
        {
            goToDropLocation = true;
        }

        private void SetLocation()
        {
            // This method is called on a timer to set the current location.
            //
            // For us, there are two tasks to do:
            //
            // 1) Set the drop location to the device location
#if UNITY_EDITOR || UNITY_STANDALONE
            _dropLocation = Conversions.StringToLatLon(_initialDropLocation);
#endif
#if UNITY_ANDROID
            // ???
#endif
#if UNITY_IOS
            // ???
#endif

            if (goToDropLocation)
            {
                goToDropLocation = false;
                _playerLocation = _dropLocation;
            }

            // 2) Set the current location to the latitude and longitude
            //    previously set by SetLatLong
            _currentLocation.UserHeading = _heading;
            _currentLocation.LatitudeLongitude = PlayerLocation;
            _currentLocation.Accuracy = _accuracy;
            _currentLocation.Timestamp = UnixTimestampUtils.To(DateTime.UtcNow);
            _currentLocation.IsLocationUpdated = true;
            _currentLocation.IsUserHeadingUpdated = true;
        }

        protected void Awake()
        {
            _wait = new WaitForSeconds(_updateInterval);
            StartCoroutine(QueryLocation());
        }

        IEnumerator QueryLocation()
        {
            // HACK: Let others register before we send our first event. 
            // Often this happens in Start.
            yield return new WaitForSeconds(.1f);
            while (true)
            {
                SetLocation();
                if (_autoFireEvent)
                {
                    SendLocation(_currentLocation);
                }
                yield return _wait;
            }
        }

        // Added to support TouchCamera script. 
        public void SendLocationEvent()
        {
            SetLocation();
            SendLocation(_currentLocation);
        }

        protected void OnValidate()
        {
            if (_sendEvent)
            {
                _sendEvent = false;
                SendLocation(_currentLocation);
            }
        }

    }
}