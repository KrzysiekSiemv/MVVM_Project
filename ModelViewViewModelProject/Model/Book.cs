using System.ComponentModel;

namespace ModelViewViewModelProject.Model
{
    public class Book : INotifyPropertyChanged
    {
        // Prywatna zmienna przechowująca ilość książek
        private int _amount;
        public int Id { get; set; }
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public double Rate { get; set; }
        // Pole, które po zmianie jej zawartości jest zmieniana zmienna _amount oraz wysyłany komunikat, że nastąpiła zmiana wartości w zmiennej
        public int Amount
        {
            get => _amount;
            set
            {
                    _amount = value;
                    OnPropertyChanged(nameof(Amount));
            }
        }

        /*
         *  Dla obiektu również potrzebujemy składnik odświeżania naszego widoku, jeżeli wiemy, że będzie również następowała zmiana wartości w naszej zmiennej
         *  jak np. ilość książek
         */
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}