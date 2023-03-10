namespace CarSystems.View
{
    public interface IDashboard
    {
        void SetDriveMode(DriveMode mode);
        void SetSpeed(float speed);
        void SetEVMode(bool isOn);
        void SetSportMode(bool isOn);
        void SetIndicator(IndicatorType type, bool isOn);
        void SetIndicatorBlinking(IndicatorType type, bool isOn);
        void NextSong();
        void PreviousSong();
        void Update(float deltaTime);
    }

    public class Dashboard : IDashboard
    {
        DriveModeHandler driveMode;
        IndicatorHandler indicatorHandler;
        MusicHandler musicHandler;
        SpeedMeter speedMeter;

        public Dashboard(UIReferences references, CarParams carParams, MusicReferences songs)
        {
            var central = references.CentralElementReferences;
            driveMode = new DriveModeHandler(central.DriveModes, central.EVIcon, central.SportIcon);
            speedMeter = new SpeedMeter(central.SpeedText, central.SpeedFillImage, carParams.Vmax);
            indicatorHandler = new IndicatorHandler(references.IndicatorReferences);
            musicHandler = new MusicHandler(references.MusicPlayerReferences, songs);
        }

        public void SetDriveMode(DriveMode mode)
        {
            driveMode.SetDriveMode(mode);
        }

        public void SetEVMode(bool isOn)
        {
            driveMode.SetEVMode(isOn);
        }

        public void SetIndicator(IndicatorType type, bool isOn)
        {
            indicatorHandler.SetIndicator(type, isOn);
        }

        public void NextSong()
        {
            musicHandler.Next();
        }

        public void PreviousSong()
        {
            musicHandler.Previous();
        }

        public void SetSpeed(float speed)
        {
            speedMeter.SetSpeed(speed);
        }

        public void SetSportMode(bool isOn)
        {
            driveMode.SetSportMode(isOn);
        }

        public void Update(float deltaTime)
        {
            musicHandler.Update(deltaTime);
            indicatorHandler.Update(deltaTime);
        }

        public void SetIndicatorBlinking(IndicatorType type, bool isOn)
        {
            indicatorHandler.SetIndicatorBlinking(type, isOn);
        }
    }
}