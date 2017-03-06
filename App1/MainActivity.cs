using Android.App;
using Android.Widget;
using Android.OS;
using Android.Hardware;

namespace App1
{
    [Activity(Label = "App1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Camera cam;
        bool isLightOn = false;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            Button btnOn = FindViewById<Button>(Resource.Id.Button02);
            Button btnOff = FindViewById<Button>(Resource.Id.Button03);
            cam = Camera.Open();
            btnOn.Click += BtnOn_Click;
            btnOff.Click += BtnOff_Click;
            
        }

        private void BtnOff_Click(object sender, System.EventArgs e)
        {
            var parms = cam.GetParameters();
            if (!isLightOn)
            {
                var dialog = new AlertDialog.Builder(this);
                dialog.SetMessage("Light is off!");
                dialog.Show();
            }
            else
            {
                parms.FlashMode = Camera.Parameters.FlashModeOff;
                cam.SetParameters(parms);
                cam.StopPreview();
                isLightOn = false;
            }
        }

        private void BtnOn_Click(object sender, System.EventArgs e)
        {
            var parms = cam.GetParameters();
            if (isLightOn)
            {
                var dialog = new AlertDialog.Builder(this);
                dialog.SetMessage("Light is on!");
                dialog.Show();
            }
            else
            {
                parms.FlashMode = Camera.Parameters.FlashModeTorch;
                cam.SetParameters(parms);
                cam.StartPreview();
                isLightOn = true;
            }
        }
    }
}

