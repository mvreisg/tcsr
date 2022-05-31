namespace Assets.Resources.Models
{
    public class XYZValue
    {
        private float _x;
        private float _y;
        private float _z;

        public float X
        {
            get => _x;
            set => _x = value;
        }

        public float Y
        {
            get => _y;
            set => _y = value;
        }

        public float Z
        {
            get => _z;
            set => _z = value;
        }

        public XYZValue(float x, float y, float z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public XYZValue() : this(0f, 0f, 0f)
        {

        }
    }
}