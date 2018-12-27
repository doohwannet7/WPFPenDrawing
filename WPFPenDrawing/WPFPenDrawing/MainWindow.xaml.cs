using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFPenDrawing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new ViewModel.MainViewModel();

            //Image1.Source = (new ImageSourceConverter()).ConvertFromString("pack://application:,,,/Resources/kubota.png") as ImageSource;
            //Image1.Source = new BitmapImage(WPFPenDrawing.Properties.Resources.kubota);
            //image1.Source = new BitmapImage(new Uri(@"pack://application:,,,/Image/kubota.PNG", UriKind.Absolute));

        }
        System.Windows.Point currentPoint = new System.Windows.Point();

        private void Canvas1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                currentPoint = e.GetPosition(this);
        }

        private void Canvas1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //SolidColorBrush blackBrush = new SolidColorBrush();
                //blackBrush.Color = Colors.Black;

                //Polyline yellowPolyline = new Polyline();
                //yellowPolyline.Stroke = blackBrush;
                //yellowPolyline.StrokeThickness = 4;

                //yellowPolyline.Points.Add(currentPoint);
                //yellowPolyline.Points.Add(e.GetPosition(this));
                //canvas1.Children.Add(yellowPolyline);

                Line line = new Line();
                line.Stroke = System.Windows.SystemColors.WindowFrameBrush;
                line.StrokeThickness = 10;
                line.StrokeLineJoin = PenLineJoin.Round;
                line.StrokeStartLineCap = PenLineCap.Round;
                line.StrokeEndLineCap = PenLineCap.Round;


                line.X1 = currentPoint.X;
                line.Y1 = currentPoint.Y;
                line.X2 = e.GetPosition(this).X;
                line.Y2 = e.GetPosition(this).Y;

                currentPoint = e.GetPosition(this);

                //canvas1.Children.Add(line);
            }
        }


        private void CreateAPolyline()
        {
            // Create a blue and a black Brush  
            SolidColorBrush yellowBrush = new SolidColorBrush();
            yellowBrush.Color = Colors.Yellow;
            SolidColorBrush blackBrush = new SolidColorBrush();
            blackBrush.Color = Colors.Black;
            // Create a polyline  
            Polyline yellowPolyline = new Polyline();
            yellowPolyline.Stroke = blackBrush;
            yellowPolyline.StrokeThickness = 4;
            // Create a collection of points for a polyline  
            System.Windows.Point Point1 = new System.Windows.Point(10, 100);
            System.Windows.Point Point2 = new System.Windows.Point(100, 200);
            System.Windows.Point Point3 = new System.Windows.Point(200, 30);
            System.Windows.Point Point4 = new System.Windows.Point(250, 200);
            System.Windows.Point Point5 = new System.Windows.Point(200, 150);
            PointCollection polygonPoints = new PointCollection();
            polygonPoints.Add(Point1);
            polygonPoints.Add(Point2);
            polygonPoints.Add(Point3);
            polygonPoints.Add(Point4);
            polygonPoints.Add(Point5);
            // Set Polyline.Points properties  
            yellowPolyline.Points = polygonPoints;
            // Add polyline to the page  
            //canvas1.Children.Add(yellowPolyline);
        }
    }
}
