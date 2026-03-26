using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Reflection;
using System.Windows.Controls.Primitives;

namespace Graphic_editor
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cnvPaint.Background = Brushes.White;
            cnvPaint.ContextMenu.AddPaletteHeader(new PanelBackgroundChanger(cnvPaint));
        }

        private AbstractShape CurrentObject; // Текущий объект для перетаскивания
        private bool DragInProgress = false; // Перетаскивание в процессе
        private Point LastPoint; // Последняя точка перетаскивания
        HitType MouseHitType = HitType.None; // Сторона прямоугольника, которой коснулась мышь
        private Point LastContextMenuPoint;  // Последняя точка, в которой было открыто контекстное меню

        private HitType SetHitType(in UIElement rect, in Point point)
        {
            double left = Canvas.GetLeft(CurrentObject);
            double top = Canvas.GetTop(CurrentObject);
            double right = left + CurrentObject.Width;
            double bottom = top + CurrentObject.Height;
            if (point.X < left) return HitType.None;
            if (point.X > right) return HitType.None;
            if (point.Y < top) return HitType.None;
            if (point.Y > bottom) return HitType.None;

            const double GAP = 10;
            if (point.X - left < GAP)
            {
                // Левая граница
                if (point.Y - top < GAP) return HitType.UL;
                if (bottom - point.Y < GAP) return HitType.LL;
                return HitType.L;
            }
            if (right - point.X < GAP)
            {
                // Правая граница
                if (point.Y - top < GAP) return HitType.UR;
                if (bottom - point.Y < GAP) return HitType.LR;
                return HitType.R;
            }
            if (point.Y - top < GAP) return HitType.T;
            if (bottom - point.Y < GAP) return HitType.B;
            return HitType.Body;
        }

        // Установка курсора мыши под нужную грань
        private void SetMouseCursor()
        {
            // Определение иконки курсора
            Cursor desired_cursor = Cursors.Arrow;
            switch (MouseHitType)
            {
                case HitType.None:
                    desired_cursor = Cursors.Arrow;
                    break;
                case HitType.Body:
                    desired_cursor = Cursors.ScrollAll;
                    break;
                case HitType.UL:
                case HitType.LR:
                    desired_cursor = Cursors.SizeNWSE;
                    break;
                case HitType.LL:
                case HitType.UR:
                    desired_cursor = Cursors.SizeNESW;
                    break;
                case HitType.T:
                case HitType.B:
                    desired_cursor = Cursors.SizeNS;
                    break;
                case HitType.L:
                case HitType.R:
                    desired_cursor = Cursors.SizeWE;
                    break;
            }

            // Отображение нужного курсора
            if (Cursor != desired_cursor) Cursor = desired_cursor;
        }

        private AbstractShape GetCurrentShape(in Point p)
        {
            if (VisualTreeHelper.HitTest(cnvPaint, p) is var hit && hit == null)
                return null;
            return hit.VisualHit is Shape child ? child.Parent as AbstractShape : hit.VisualHit as AbstractShape;
        }

        // Команды для открытия, сохранения и закрытия файла
        private void NewBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {                  
            if (MessageBox.Show(this, "Хотите сохранить файл?", "Подтвеждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                SaveBinding_OnExecuted(sender, e);
            Clear();
            cnvPaint.Background = Brushes.White;
        }

        private void OpenBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            statBarTextBlock.Text = "Открытие...";
            ImageBrush brush = new ImageBrush();
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.AddExtension = true;
            openDialog.CheckFileExists = true;
            openDialog.DefaultExt = "png";
            openDialog.Filter = "Image files|*.png;*.jpeg;*.ico|All files (*.*)|*.*";
            double imageWidth=0, imageHeight=0;
            if (openDialog.ShowDialog() == true && openDialog.SafeFileName != "")
            {
                Clear();
                brush.ImageSource = new BitmapImage(new Uri(openDialog.FileName));
                imageWidth = brush.ImageSource.Width;
                imageHeight = brush.ImageSource.Height;
                cnvPaint.Width = imageWidth;
                cnvPaint.Height = imageHeight;
                brush.Stretch = Stretch.Uniform;
                cnvPaint.Background = brush;
            }
            statBarTextBlock.Text = "Готово";
        }

        private void SaveBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            statBarTextBlock.Text = "Сохранение...";
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = "PNG (*.png)|*.png|JPEG (*.jpg)|*.jpg|All(*.*)|*",
                FileName = "Безымянный",
                DefaultExt = "png",
            };
            int cw = (int)cnvPaint.Width;
            int ch = (int)cnvPaint.Height;
            RenderTargetBitmap renderBitmap = new RenderTargetBitmap(cw, ch, 96d, 96d, PixelFormats.Pbgra32);
            cnvPaint.Measure(new Size(cw, ch));
            cnvPaint.Arrange(new Rect(new Size(cw, ch)));
            renderBitmap.Render(cnvPaint);
            InvalidateVisual();
            if (saveFileDialog.ShowDialog() == true)
            {
                var extension = System.IO.Path.GetExtension(saveFileDialog.FileName);
                using (FileStream file = File.Create(saveFileDialog.FileName))
                {
                    BitmapEncoder encoder = null;
                    switch (extension.ToLower())
                    {
                        case ".jpg":
                            encoder = new JpegBitmapEncoder();
                            break;
                        case ".png":
                            encoder = new PngBitmapEncoder();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(extension);
                    }
                    encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
                    encoder.Save(file);
                }
            }
            statBarTextBlock.Text = "Готово";
        }

        private void CloseBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e) => Close();

        // Метод для очистки холста
        private void Clear()
        {
            cnvPaint.Children.Clear();
            undo_redo.undoCommands.Clear();
            undo_redo.redoCommands.Clear();
            btnRedo.IsEnabled = false;
            btnUndo.IsEnabled = false;
        }
        
        public ToolType currentTool { get; set; } = ToolType.None; // Текущий выбранный инструмент
        public bool onCanvas = false; // флаг о рисовании именно на холсте
        Point startPoint; // пара координат стартовой точки относительно canvas 
        Shape currentShape = null;
        MouseButtonState previousMouseEvent = new MouseButtonState(); //предыдущее состоянии мыши
        Brush currentBrush = Brushes.Black;
        int currentBrushThickness = 1;
        PathFigure currentFigure; // текущая траектория мыши на холсте, созданная при инструментах карандаш, либо кисть, либо ластик
        System.Windows.Shapes.Path currentPath = null;
        UndoRedo undo_redo = new UndoRedo();

        // Обработчик события клика на карандаш
        private void BtnPencil_Click(object sender, RoutedEventArgs e)
        {
            currentTool = ToolType.Pencil;
            spThickness.IsEnabled = false;
            statBarTextBlock.Text = "Выбрано: Карандаш";
        }

        // Обработчик события клика на кисточку
        private void BtnBrush_Click(object sender, RoutedEventArgs e)
        {
            currentTool = ToolType.Brush;
            spThickness.IsEnabled = true;
            statBarTextBlock.Text = "Выбрано: Кисть";
        }
        
        // Обработчик события клика на пипетку
        private void BtnPipette_Click(object sender, RoutedEventArgs e)
        {
            currentTool = ToolType.Pipette;
            spThickness.IsEnabled = false;
            statBarTextBlock.Text = "Выбрано: Пипетка";
        }
        
        // Обработчик события клика на ластик
        private void BtnEraser_Click(object sender, RoutedEventArgs e)
        {
            currentTool = ToolType.Eraser;
            spThickness.IsEnabled = true;
            statBarTextBlock.Text = "Выбрано: Ластик";
        }
        
        // Обработчики событий кликов на кнопки фигур(линия, эллипс, прямоугольник)
        private void BtnLine_Click(object sender, RoutedEventArgs e)
        {
            currentTool = ToolType.Line;
            spThickness.IsEnabled = true;
            statBarTextBlock.Text = "Выбрано: Линия";
        }

        // Метод для рисования линии
        private void DrawLine(MouseEventArgs e)
        {
            Line line = new Line()
            {
                Stroke = currentBrush,
                StrokeThickness = currentBrushThickness,
                X1 = startPoint.X,
                Y1 = startPoint.Y,
                X2 = e.GetPosition(cnvPaint).X,
                Y2 = e.GetPosition(cnvPaint).Y
            };
            cnvPaint.Children.Add(line);
            currentShape = line;
        }

        // Обработчики событий клика на холст(cnvPaint) и движения по нему мышкой
        private void CnvPaint_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (previousMouseEvent != MouseButtonState.Pressed)
                onCanvas = true;
            startPoint = e.GetPosition(cnvPaint);
            if (currentTool == ToolType.Pipette)
                GetColor((int)e.GetPosition(this).X, (int)e.GetPosition(this).Y);
            if (currentTool == ToolType.Pencil || currentTool == ToolType.Brush || currentTool == ToolType.Eraser)
                StartDraw();
            else if (e.ButtonState == MouseButtonState.Pressed)
                currentShape = new Line();
            
            if (GetCurrentShape(e.GetPosition(cnvPaint)) is var fix && fix == null)
                return;
            CurrentObject = fix;
            MouseHitType = SetHitType(CurrentObject, Mouse.GetPosition(cnvPaint));
            SetMouseCursor();
            if (MouseHitType == HitType.None) return;

            LastPoint = Mouse.GetPosition(cnvPaint);
            DragInProgress = true;
        }

        private void CnvPaint_MouseMove(object sender, MouseEventArgs e)
        {
            if (onCanvas && OnCanvas(e))
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    switch (currentTool)
                    {
                        case ToolType.Line:
                            cnvPaint.Children.Remove(currentShape);
                            DrawLine(e);
                            break;
                        case ToolType.Pencil:
                        case ToolType.Brush:
                        case ToolType.Eraser:
                            cnvPaint.Children.Remove(currentPath);
                            AddDraw(e);
                            break;
                    }
                }
                else if (e.LeftButton == MouseButtonState.Released && previousMouseEvent == MouseButtonState.Pressed)
                {
                    if (currentTool == ToolType.Pencil || currentTool == ToolType.Brush || currentTool == ToolType.Eraser)
                    {
                        DrawWithPencilCommand command = new DrawWithPencilCommand(currentPath, cnvPaint);
                        undo_redo.AddComand(command);
                        currentFigure = null;
                        currentPath = null;
                    }
                    else
                    {
                        DrawCommand command = new DrawCommand(currentShape, cnvPaint);
                        undo_redo.AddComand(command);
                    }
                    btnUndo.IsEnabled = true;
                    onCanvas = false;
                }
                previousMouseEvent = e.LeftButton;
                statBarTextBlock.Text = "Готово | X: " + Mouse.GetPosition(cnvPaint).X.ToString() + "; Y: " + Mouse.GetPosition(cnvPaint).Y.ToString();
            }

            // Обновление прямоугольника
            if (CurrentObject == null)
                return;
            if (!DragInProgress)
            {
                MouseHitType = SetHitType(CurrentObject, Mouse.GetPosition(cnvPaint));
                SetMouseCursor();
            }
            else
            {
                // Расчет, насколько сдвинулась мышь
                Point point = Mouse.GetPosition(cnvPaint);
                double offset_x = point.X - LastPoint.X;
                double offset_y = point.Y - LastPoint.Y;

                // Получиение текущей позиции прямоугольника
                double new_x = Canvas.GetLeft(CurrentObject);
                double new_y = Canvas.GetTop(CurrentObject);
                double new_width = CurrentObject.Width;
                double new_height = CurrentObject.Height;
                currentTool = ToolType.None;


                switch (MouseHitType)
                {
                    case HitType.Body:
                        new_x += offset_x;
                        new_y += offset_y;
                        break;
                    case HitType.UL:
                        new_x += offset_x;
                        new_y += offset_y;
                        new_width -= offset_x;
                        new_height -= offset_y;
                        break;
                    case HitType.UR:
                        new_y += offset_y;
                        new_width += offset_x;
                        new_height -= offset_y;
                        break;
                    case HitType.LR:
                        new_width += offset_x;
                        new_height += offset_y;
                        break;
                    case HitType.LL:
                        new_x += offset_x;
                        new_width -= offset_x;
                        new_height += offset_y;
                        break;
                    case HitType.L:
                        new_x += offset_x;
                        new_width -= offset_x;
                        break;
                    case HitType.R:
                        new_width += offset_x;
                        break;
                    case HitType.B:
                        new_height += offset_y;
                        break;
                    case HitType.T:
                        new_y += offset_y;
                        new_height -= offset_y;
                        break;
                }

                // Не использовать отрицательные ширину и высоту
                if ((new_width > 0) && (new_height > 0))
                {
                    // Обновление прямоугольника
                    Canvas.SetLeft(CurrentObject, new_x);
                    Canvas.SetTop(CurrentObject, new_y);
                    CurrentObject.Width = new_width;
                    CurrentObject.Height = new_height;

                    // Сохранение нового положения мыши
                    LastPoint = point;
                }
            }
        }

        private void MainCanvasMouseUp(object sender, MouseButtonEventArgs e) => DragInProgress = false;

        private void RectangleClick(object sender, RoutedEventArgs e)
        {
            cnvPaint.Children.Add(new MyRectangle(LastContextMenuPoint, new SolidColorBrush(colorPicker.SelectedColor.Value)));
            currentTool = ToolType.Rectangle;
            spThickness.IsEnabled = false;
        }

        private void TriangleClick(object sender, RoutedEventArgs e)
        {
            cnvPaint.Children.Add(new MyTriangle(LastContextMenuPoint, new SolidColorBrush(colorPicker.SelectedColor.Value)));
            currentTool = ToolType.Triangle;
            spThickness.IsEnabled = false;
        }

        private void EllipseClick(object sender, RoutedEventArgs e)
        {
            cnvPaint.Children.Add(new MyEllipse(LastContextMenuPoint, new SolidColorBrush(colorPicker.SelectedColor.Value)));
            currentTool = ToolType.Ellipse;
            spThickness.IsEnabled = false;
        }

        // Метод, определяющий принадлежит ли точка холсту
        private bool OnCanvas(MouseEventArgs e)
        {
            if (e.GetPosition(cnvPaint).Y-currentBrushThickness>0)
                return true;
            return false;
        }

        // Обработчики событий кликов на кнопки назад и вперед
        private void BtnUndo_Click(object sender, RoutedEventArgs e)
        {
            statBarTextBlock.Text = "Отмена действия...";
            undo_redo.Undo(1);
            btnRedo.IsEnabled = true;
            if (undo_redo.undoCommands.Count == 0)
                btnUndo.IsEnabled = false;
            statBarTextBlock.Text = "Готово";
        }

        private void BtnRedo_Click(object sender, RoutedEventArgs e)
        {
            statBarTextBlock.Text = "Возврат действия...";
            undo_redo.Redo(1);
            btnUndo.IsEnabled = true;
            if (undo_redo.redoCommands.Count == 0)
                btnRedo.IsEnabled = false;
            statBarTextBlock.Text = "Готово";
        }

        // Обработчик события изменения цвета
        private void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (colorPicker.SelectedColor != null)
                currentBrush = new SolidColorBrush((Color)colorPicker.SelectedColor);
        }

        // Обработчик события изменения толщины кисти 
        private void SlBrushThickness_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) => currentBrushThickness = (int)e.NewValue;

        // Методы, реализующие логику работы карандаша, кисти, ластика
        private void StartDraw()
        {
            currentFigure = new PathFigure() { StartPoint = startPoint };
            System.Windows.Shapes.Path path = new System.Windows.Shapes.Path()
            {
                Stroke = currentBrush,
                StrokeThickness = 0.5,
                Data = new PathGeometry() { Figures = { currentFigure } }
            };
            if (currentTool == ToolType.Eraser)
                path.Stroke = Brushes.White;
            if (currentTool == ToolType.Brush || currentTool == ToolType.Eraser)
                path.StrokeThickness = currentBrushThickness;
            cnvPaint.Children.Add(path);
            currentPath = path;
        }

        private void AddDraw(MouseEventArgs e)
        {
            currentFigure.Segments.Add(new LineSegment(e.GetPosition(cnvPaint), isStroked: true));
            currentPath.Data = new PathGeometry() { Figures = { currentFigure } };
            cnvPaint.Children.Add(currentPath);
        }

        // Получение цвета пикселя изображения
        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        static extern Int32 ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [DllImport("gdi32.dll")]
        static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

        public Color GetPixelColor(IntPtr hwnd, int x, int y)
        {
            IntPtr hdc = GetDC(hwnd);
            uint pixel = GetPixel(hdc, x, y);
            ReleaseDC(hwnd, hdc);
            Color color = Color.FromRgb((byte)(pixel & 0x000000FF), (byte)((pixel & 0x0000FF00) >> 8), (byte)((pixel & 0x00FF0000) >> 16));
            return color;
        }

        public void GetColor(int x, int y)
        {
            IntPtr hwnd = new WindowInteropHelper(Application.Current.MainWindow).Handle;
            var pixel = GetPixelColor(hwnd, x, y);
            currentBrush = new SolidColorBrush(pixel);
            colorPicker.SelectedColor = pixel;
        }

        // Обработчик события нажатия на вкладку окна About
        private void MAbout_Click(object sender, RoutedEventArgs e) => MessageBox.Show("Простой графический редактор" + Environment.NewLine + "Разработчик: Сушко Алексей Юльевич\n", "Информация о программе", MessageBoxButton.OK, MessageBoxImage.Information);

        // Обработчик события выбора элемента меню "Properties" из вкладки "Edit"
        private void MProperties_Click(object sender, RoutedEventArgs e)
        {
            ImageProperty propertyWindow = new ImageProperty((int)cnvPaint.Width, (int)cnvPaint.Height);
            propertyWindow.Owner = this;
            propertyWindow.Show();
        }

        // Закрытие приложения (сообщение)
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show(this, "Вы уверены что хотите закрыть это окно?", "Подтвеждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void cnvPaint_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            cnvBorder.Width = cnvPaint.Width + 8;
            cnvBorder.Height = cnvPaint.Height + 8;
        }
    }
}