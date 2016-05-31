using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
namespace TouchWalkthrough
{
    /// <summary>
    ///   The main activity is implemented as a ListActivity. When the user
    ///   clicks on a item in the ListView, we will display the appropriate activity.
    /// </summary>
    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/ic_launcher")]
    public class MainActivity : Activity, View.IOnTouchListener
    {
        private float _viewX;
        private float _viewY;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            var scrollView = new ScrollView(this)
            {
                LayoutParameters =
                           new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent)
            };

            this.SetContentView(scrollView);

            var mainLayout = new LinearLayout(this)
            {
                Orientation = Orientation.Vertical,
                LayoutParameters =
                           new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent)

            };

            scrollView.AddView(mainLayout);

            for (int n = 1; n < 15; n++)
            {
                var dv = new DynamicView(this, n)
                {
                    LayoutParameters =
                             new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 200)

                };
                dv.SetOnTouchListener(this);
                mainLayout.AddView(dv);
            }
        }
        public bool OnTouch(View v, MotionEvent e)
        {
            switch (e.Action)
            {
                case MotionEventActions.Down:
                    _viewX = e.GetX();
                    _viewY = e.GetY();
                    break;
                case MotionEventActions.Move:
                    var left = (int)(e.RawX - _viewX);
                    var right = (left + v.Width);
                    var top = (int)(e.RawY - _viewY - 150);
                    var bottom = (top + v.Height);
                    v.Layout(left, top, right, bottom);
                    break;
            }

            return true;
        }

    }
}
