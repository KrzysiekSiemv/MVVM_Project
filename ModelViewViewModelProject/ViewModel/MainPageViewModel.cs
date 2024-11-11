using ModelViewViewModelProject.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ModelViewViewModelProject.ViewModel
{
    // Należy pamiętać o przypisaniu naszej klasy do interfejsu INotifyPropertyChanged. Wymagane jest zainicjowanie przestrzeni System.ComponentModel
    class MainPageViewModel : INotifyPropertyChanged
    {
        // Obiekt służący do tworzenia odświeżalnej listy
        public ObservableCollection<Book> Books { get; set; }

        // Obiekt do stworzenia nowej książki
        public Book NewBook { get; set; }
        
        // Komendy do zarządzania tym modelem
        public ICommand AddBookCmd { get; }
        public ICommand IncreaseAmountBookCmd { get; }
        public ICommand DecreaseAmountBookCmd { get; }

        public MainPageViewModel()
        {
            Books = new ObservableCollection<Book>
            {
                new Book { Id = 1, Title = "Pan Tadeusz", Price = 29.99m, Rate = 4.5, Amount = 5 },
                new Book { Id = 1, Title = "Życie na krawędzi", Price = 14.99m, Rate = 4, Amount = 3 },
                new Book { Id = 1, Title = "Czym jest życie", Price = 19.99m, Rate = 5, Amount = 6 }
            };

            // Pusty obiekt, który służy do pobierania wartości z pól w widoku i dodawania nowej książki do listy Books.
            NewBook = new Book();

            // Przypisywanie utworzonych funkcji do naszych komend
            AddBookCmd = new Command(AddBook);
            IncreaseAmountBookCmd = new Command<Book>(IncreaseAmount);
            DecreaseAmountBookCmd = new Command<Book>(DecreaseAmount);
        }

        private void AddBook()
        {
            NewBook.Id = Books.Count + 1;
            Books.Add(new Book
            {
                Id = NewBook.Id,
                Title = NewBook.Title,
                Price = NewBook.Price,
                Rate = NewBook.Rate,
                Amount = NewBook.Amount
            });

            NewBook = new Book();
            OnPropertyChanged(nameof(NewBook));
        }

        private void IncreaseAmount(Book book)
        {
            book.Amount++;
        }

        private void DecreaseAmount(Book book)
        {
            book.Amount--; 
        }

        /*
         *  GŁÓWNE SKŁADNIKI NASZEJ STRUKTURY MVVM
         *  Poza przypisaniem naszej klasy MainPageViewModel do interfejsu INotifyPropertyChanged potrzebujemy również
         *  utworzyć zdarzenie PropertyChanged oraz funkcje OnPropertyChanged(string propertyName) które służy do
         *  powiadomienia naszego widoku, że nastąpiła zmiana w naszych obiektach i ma odświeżyć dane w widoku!
         */
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
