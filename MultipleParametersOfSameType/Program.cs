namespace MultipleParameters
{
    public struct Size
    {
        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public struct Size2
    {
        public Size2(Width2 width, Height2 height)
        {
            Width = width;
            Height = height;
        }
        public Width2 Width { get; set; }
        public Height2 Height { get; set; }
    }

    public struct Size3
    {
        public Size3(Width3 width, Height3 height)
        {
            Width = width;
            Height = height;
        }
        public Width3 Width { get; set; }
        public Height3 Height { get; set; }
    }

    public struct Size4
    {
        public Size4(int w, int h)
        {
            Width = new Width4(w);
            Height = new Height4(h);
        }
        public Size4(Width4 width, Height4 height)
        {
            Width = width;
            Height = height;
        }
        public Width4 Width { get; set; }
        public Height4 Height { get; set; }
    }

    public class Height2
    {
        public Height2(int height)       // constructor
        {
            Value = height;
        }
        public int Value { get; set; }
    }

    public class Width2
    {
        public Width2(int width)
        {
            Value = width;
        }
        public int Value { get; set; }
    }

    public class Height3
    {
        public Height3(int height)       // constructor
        {
            Value = height;
        }
        public static explicit operator Height3(int height) // explicit int to Height2 conversion
        {
            Height3 h = new Height3(height);
            return h;
        }
        public int Value { get; set; }
    }

    public class Width3
    {
        public Width3(int width)
        {
            Value = width;
        }
        public static explicit operator Width3(int width) // explicit int to Width3 conversion
        {
            Width3 w = new Width3(width);
            return w;
        }
        public int Value { get; set; }
    }

    public class Height4
    {
        public Height4(int height)       // constructor
        {
            Value = height;
        }
        public static implicit operator int(Height4 height) // implicit Height4 to int conversion
        {
            return height.Value;
        }
        public int Value { get; set; }
    }

    public class Width4
    {
        public Width4(int width)
        {
            Value = width;
        }
        public static implicit operator int(Width4 width) // implicit Width4 to int conversion
        {
            return width.Value;
        }
        public int Value { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Size size1 = new Size(640, 480);
            Size size2 = new Size(480, 640);                                    // compiles, but wrong
            Size size3 = new Size(height: 480, width: 640);
            var height1 = size1.Height;
            var width1 = size1.Width;

            Width2 aWidth2 = new Width2(640);
            Height2 aHeight2 = new Height2(480);
            Size2 size21 = new Size2(aWidth2, aHeight2);
            Size2 size22 = new Size2(aHeight2, aWidth2);                          // compiler reports error
            Size2 size23 = new Size2(height: aHeight2, width: aWidth2);
            var height2 = size21.Height.Value;
            var width2 = size21.Width.Value;

            Size3 size31 = new Size3(new Width3(640), new Height3(480));
            Size3 size32 = new Size3((Width3)640, (Height3)480);
            Size3 size33 = new Size3((Height3)480, (Width3)640);                // compiler reports error
            Size3 size34 = new Size3(height: (Height3)480, width: (Width3)640);
            int height3 = size32.Height.Value;
            int width3 = size32.Width.Value;

            Size4 size41 = new Size4(new Width4(640), new Height4(640));
            int width4 = size41.Width;
            int height4 = size41.Height;

            var width = new Width4(640);
            var height = new Height4(480);
            Size size4 = new Size(width, height);
            Size size5 = new Size(height, width);                               // compiles, but wrong
            Size size6 = new Size(height: height, width: width);
        }
    }
}
