using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Paint
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly InkCanvasWithUndo inkCanvas;
        private readonly Stack<IMemento> statesUndo;
        private readonly Stack<IMemento> statesRedo;
        private readonly CommandBindingCollection commandBindings;

        private int count;
        public int Count
        {
            get { return count - 1; }
            set
            {
                count = value;
                OnPropertyChanged("Count");
            }
        }
        public MainWindowViewModel(MainWindow mainWindow)
        {
            statesUndo = new Stack<IMemento>();
            statesRedo = new Stack<IMemento>();

            commandBindings = mainWindow.CommandBindings;
            inkCanvas = mainWindow.InkCanvasWithUndo1;

            inkCanvas.MouseUp += InkCanvasWithUndo1_MouseUp;

            //Create a command binding for the save command
            var saveBindingUndo = new CommandBinding(ApplicationCommands.Undo, OnExecutedCommandsUndo);
            var saveBindingRedo = new CommandBinding(ApplicationCommands.Redo, OnExecutedCommandsRedo);

            //Register the binding to the class
            CommandManager.RegisterClassCommandBinding(typeof (MainWindowViewModel), saveBindingUndo);

            //Adds the binding to the CommandBindingCollection
            commandBindings.Add(saveBindingUndo);
            commandBindings.Add(saveBindingRedo);

            StoreState();
        }

        private void OnExecutedCommandsRedo(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Redo)
            {
                Redo(sender, e);
            }
        }

        private void Redo(object sender, ExecutedRoutedEventArgs executedRoutedEventArgs)
        {
                
                if (statesRedo.Any())
                {
                var lastState = statesRedo.Pop();
                inkCanvas.SetMemento(lastState);
                statesUndo.Push(lastState);
            }
                Count = statesUndo.Count;
          
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void StoreState()
        {
            // Save state to memento
            var memento = inkCanvas.CreateMemento();
            statesUndo.Push(memento);
            Count = statesUndo.Count;
        }

        /// <summary>
        ///     Undo the last edit.
        /// </summary>
        private void Undo(object sender, RoutedEventArgs e)
        {
           
            if (statesUndo.Count > 1)
            {
                // discard current state
                statesRedo.Push(statesUndo.Pop());
                var lastState = statesUndo.Peek();
                inkCanvas.SetMemento(lastState);
            }
            Count = statesUndo.Count;
        }

        private void InkCanvasWithUndo1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            StoreState();
        }

        private void OnExecutedCommandsUndo(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Undo)
            {
                Undo(sender, e);
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}