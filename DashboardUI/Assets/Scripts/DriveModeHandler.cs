using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CarSystems.View
{
    public class DriveModeHandler
    {
        Dictionary<DriveMode, TextMeshProUGUI> modes;

        Color startingColor;
        Color selectedColor = Color.white;
        DriveMode selectedMode;

        public DriveModeHandler(DriveModeReference[] references)
        {
            modes = new Dictionary<DriveMode, TextMeshProUGUI>();
            foreach (DriveModeReference reference in references)
            {
                modes[reference.Mode] = reference.ModeText;
            }

            startingColor = modes[DriveMode.Neutral].color;
            SetDriveMode(DriveMode.Parking);
        }

        public void SetDriveMode(DriveMode mode)
        {
            modes[selectedMode].fontStyle = FontStyles.Normal;
            modes[selectedMode].color = startingColor;
            selectedMode = mode;
            modes[selectedMode].fontStyle = FontStyles.Bold;
            modes[selectedMode].color = selectedColor;
        }
    }
}