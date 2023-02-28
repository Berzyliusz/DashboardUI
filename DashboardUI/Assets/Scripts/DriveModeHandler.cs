using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CarSystems.View
{
    public class DriveModeHandler
    {
        private readonly Image evIcon;
        private readonly Image sportIcon;
        Dictionary<DriveMode, TextMeshProUGUI> modes;

        Color startingColor;
        Color selectedColor = Color.white;
        DriveMode selectedMode;

        public DriveModeHandler(DriveModeReference[] references, Image evIcon, Image sportIcon)
        {
            modes = new Dictionary<DriveMode, TextMeshProUGUI>();
            foreach (DriveModeReference reference in references)
            {
                modes[reference.Mode] = reference.ModeText;
            }

            startingColor = modes[DriveMode.Neutral].color;
            SetDriveMode(DriveMode.Parking);
            this.evIcon = evIcon;
            this.sportIcon = sportIcon;
        }

        public void SetDriveMode(DriveMode mode)
        {
            modes[selectedMode].fontStyle = FontStyles.Normal;
            modes[selectedMode].color = startingColor;
            selectedMode = mode;
            modes[selectedMode].fontStyle = FontStyles.Bold;
            modes[selectedMode].color = selectedColor;
        }

        public void SetSportMode(bool isOn)
        {
            sportIcon.enabled = isOn;
        }

        public void SetEVMode(bool isOn)
        {
            evIcon.enabled = isOn;
        }
    }
}