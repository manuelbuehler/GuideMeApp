namespace GuideMeApp.Models
{
    public class UserSetting : BaseEntity
    {
        public bool ScreenReader { get; set; }

        public bool BlinkBlocker { get; set; }

        public bool TextEnlargement { get; set; }

        public bool HighContrast { get; set; }

        public bool TextReader { get; set; }

        public bool VoiceCommands { get; set; }
    }
}
