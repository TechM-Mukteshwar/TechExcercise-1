using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.Views;

namespace TouchWalkthrough
{
    class MySquareShape : View
    {
        private readonly ShapeDrawable _shape;

        public MySquareShape(Context context) : base(context)
        {
            var paint = new Paint();
            paint.SetARGB(255, 6, 98, 222);
            paint.SetStyle(Paint.Style.Fill);
            //paint.SetStyle(Paint.Style.Stroke);
            paint.StrokeWidth = 4;

            _shape = new ShapeDrawable(new RectShape());
            _shape.Paint.Set(paint);
            
            
            _shape.SetBounds(20, 20, 100, 100);
        }

        protected override void OnDraw(Canvas canvas)
        {
            _shape.Draw(canvas);
        }
    }
}