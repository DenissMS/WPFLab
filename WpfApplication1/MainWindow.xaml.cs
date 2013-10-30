using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var save = new CommandBinding(ApplicationCommands.Save, execute_Save, canExecute_Save);
            CommandBindings.Add(save);
            var open = new CommandBinding(ApplicationCommands.Open, execute_Open, canExecute_Open);
            CommandBindings.Add(open);
            var close = new CommandBinding(ApplicationCommands.Close, execute_Close, canExecute_Close);
            CommandBindings.Add(close);
            var copy = new CommandBinding(ApplicationCommands.Copy, execute_Copy, canExecute_Copy);
            CommandBindings.Add(copy);
            var paste = new CommandBinding(ApplicationCommands.Paste, execute_Paste, canExecute_Paste);
            CommandBindings.Add(paste);
        }

        static void canExecute_Open(object sender, CanExecuteRoutedEventArgs e)
        { e.CanExecute = true; }

        static void canExecute_Copy(object sender, CanExecuteRoutedEventArgs e)
        { e.CanExecute = true; }

        static void canExecute_Paste(object sender, CanExecuteRoutedEventArgs e)
        { e.CanExecute = true; }

        static void canExecute_Close(object sender, CanExecuteRoutedEventArgs e)
        { e.CanExecute = true; }

        private void execute_Open(object sender, ExecutedRoutedEventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                Filter = "Текстовые файлв (*.txt)|*.txt|Показать все файлы (*.*)|*.*",
                Title = "Открыть файл..."
            };

            if (dlg.ShowDialog() == true)
            {
                TbText.Text = System.IO.File.ReadAllText(dlg.FileName);
            }
        }

        private void execute_Close(object sender, ExecutedRoutedEventArgs e)
        {
            TbText.Clear();
        }
        private void execute_Copy(object sender, ExecutedRoutedEventArgs e)
        {
            Clipboard.SetText(TbText.Text);
        }

        private void execute_Paste(object sender, ExecutedRoutedEventArgs e)
        {
            TbText.Text = Clipboard.GetText();
        }

        private void Border_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Border_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        void canExecute_Save(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = TbText.Text.Trim().Length > 0;
        }

        void execute_Save(object sender, ExecutedRoutedEventArgs e)
        {
            var dlg = new SaveFileDialog
            {
                Filter = "Текстовые файлв (*.txt)|*.txt|Показать все файлы (*.*)|*.*",
                FileName = "Безымянный",
                Title = "Сохранить как..."
            };

            if (dlg.ShowDialog()==true)
            {
                System.IO.File.WriteAllText(dlg.FileName, TbText.Text);
            }
        }
    }
}
