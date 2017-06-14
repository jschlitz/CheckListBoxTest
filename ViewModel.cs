using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace CheckListBoxTest
{
  public class ViewModel
  {
    public ViewModel()
    {
      AllItems = new ReadOnlyCollection<string>(new[] { "foo", "bar", "baz", "inka", "dinka", "doo", "wibble", "wobble", "bop" });
      SelectedItems = new ObservableCollection<string>(new[] { "bar", "baz", "dinka", "wibble"});
      Checked = new CheckedCommand(this);
    }
    public ReadOnlyCollection<string> AllItems { get; set; }
    public ObservableCollection<string> SelectedItems { get; set; }

    public CheckedCommand Checked { get; set; }

    public class CheckedCommand : ICommand
    {
      public CheckedCommand(ViewModel owner)
      {
        Owner = owner;
      }

      public ViewModel Owner { get; private set; }

      public void Execute(object parameter)
      {
        Debug.WriteLine(string.Join(", ", Owner.SelectedItems));
      }

      public bool CanExecute(object parameter)
      {
        return true;
      }

      public event EventHandler CanExecuteChanged;
    }

  }
}
