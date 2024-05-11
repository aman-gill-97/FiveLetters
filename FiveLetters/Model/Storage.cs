using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveLetters.Model
{
    public class Storage
    {
        public int rowIndex { get; set; }
        public int columnIndex { get; set; }
        public int guessCounter { get; set; }
        public char[] correctAnswer { get; set; }
        public WordRow[] Rows { get; set; }
        public UserStats UserStats { get; set; }
        public ObservableCollection<Key> KeyboardList1 { get; set; }
        public ObservableCollection<Key> KeyboardList2 { get; set; }
        public ObservableCollection<Key> KeyboardList3 { get; set; }

    }
}
