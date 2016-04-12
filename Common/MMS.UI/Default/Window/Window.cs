using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MMS.UI.Default
{
    public class Window : System.Windows.Window
    {
        private System.Windows.Controls.Button mCloseBtn;
        private System.Windows.Controls.Button mMinBtn;
        private System.Windows.Controls.Button mMaxBtn;
        private System.Windows.Controls.Button mRestoreBtn;
        private DockPanel mTitleBorder;



        public bool IsCanMax
        {
            get { return (bool)GetValue(IsCanMaxProperty); }
            set { SetValue(IsCanMaxProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsCanMax.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsCanMaxProperty =
            DependencyProperty.Register("IsCanMax", typeof(bool), typeof(Window), new PropertyMetadata(true));



        public Window()
        {
            this.Style = (Style)Application.Current.Resources["DefaultWindowStyle"];
            FullScreenManager.RepairWpfWindowFullScreenBehavior(this);
            this.Loaded += DefaultWindow_Loaded;
        }

        public override void OnApplyTemplate()
        {
            this.mCloseBtn = (System.Windows.Controls.Button)this.GetTemplateChild("closeBtn");
            this.mMinBtn = (System.Windows.Controls.Button)this.GetTemplateChild("minBtn");
            this.mMaxBtn = (System.Windows.Controls.Button)this.GetTemplateChild("maxBtn");
            this.mRestoreBtn = (System.Windows.Controls.Button)this.GetTemplateChild("restoreBtn");
            this.mTitleBorder = (DockPanel)this.GetTemplateChild("titleBorder");
            base.OnApplyTemplate();
        }

        private void DefaultWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.mCloseBtn.Click += MCloseBtn_Click;
            this.mMinBtn.Click += mMinBtn_Click;
            this.mMaxBtn.Click += mMaxBtn_Click;
            this.mRestoreBtn.Click += mRestoreBtn_Click;
            this.mTitleBorder.MouseMove += mTitleBorder_MouseMove;
            this.mMaxBtn.DataContext = this;
            this.mMaxBtn.SetBinding(Button.IsEnabledProperty, "IsCanMax");
        }

        void mTitleBorder_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if(e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        void mRestoreBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Normal;
        }

        void mMaxBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Maximized;
        }

        void mMinBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void MCloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
