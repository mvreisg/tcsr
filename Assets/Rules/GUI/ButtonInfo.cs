namespace Assets.Rules.GUI
{
    public sealed class ButtonInfo
    {
        private readonly Buttons _button;
        private readonly bool _pressed;

        public ButtonInfo(Buttons button, bool pressed)
        {
            _button = button;
            _pressed = pressed;
        }

        public Buttons Button => _button;

        public bool Pressed => _pressed;
    }
}