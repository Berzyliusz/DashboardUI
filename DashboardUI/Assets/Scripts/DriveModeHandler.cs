using TMPro;

namespace CarSystems.View
{
    public class DriveModeHandler
    {
        private readonly TextMeshProUGUI parkingMode;
        private readonly TextMeshProUGUI reverseMode;
        private readonly TextMeshProUGUI neutralMode;
        private readonly TextMeshProUGUI driveMode;

        public DriveModeHandler(TextMeshProUGUI parkingMode, TextMeshProUGUI reverseMode, TextMeshProUGUI neutralMode, TextMeshProUGUI driveMode)
        {
            this.parkingMode = parkingMode;
            this.reverseMode = reverseMode;
            this.neutralMode = neutralMode;
            this.driveMode = driveMode;
        }
    }
}