using System.Linq;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using System.Collections.Generic;

namespace TouchWalkthrough
{
    public class DynamicView : LinearLayout
    {
        private List<View> layouts;

        public DynamicView(Context context, int count) :
            base(context)
        {
            this.Initialize(count);
        }

        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            base.OnSizeChanged(w, h, oldw, oldh);

            foreach (var l in this.layouts)
            {
                l.LayoutParameters = new LinearLayout.LayoutParams(w / this.layouts.Count, ViewGroup.LayoutParams.WrapContent);
            }
        }

        private void Initialize(int count)
        {
            View myNewView = null;
            this.Orientation = Orientation.Horizontal;
            //this.SetBackgroundColor(new Color(20, 125, 0));
            layouts = new List<View>();
            for (int n = 0; n < count; n++)
            {
                var layout = new LinearLayout(this.Context)
                {
                    Orientation = Orientation.Vertical,
                    LayoutParameters =
                            new LinearLayout.LayoutParams(this.Width / count, ViewGroup.LayoutParams.WrapContent)
                };

                layouts.Add(layout);
                if (n % 3 == 0)
                    myNewView = new MyOvalShape(this.Context);
                else
                    myNewView = new MySquareShape(this.Context);
                layout.AddView(myNewView);

                this.AddView(layout);
            }
        }
    }
}