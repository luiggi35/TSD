//using HomeLibrary;
using System;
using System.Collections.Generic;
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



using HomeLibrary;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static List<Book> books = MyBookCollection.GetMyCollection();
        private int cpt;

        public MainWindow()
        {

            InitializeComponent();
            this.lBooks.ItemsSource = books;
            cpt = lBooks.Items.Count+1;
            

        }

        
        
       

        

        private void Button_Add_Book(object sender, RoutedEventArgs e)
        {
            
            Book newBook = new Book(cpt);
            newBook.Author = newAuthor.Text.ToString();
            newBook.Title = newTitle.Text.ToString();
            newBook.IsRead = newIsRead.IsChecked.Value;
            newBook.Year = Int32.Parse(newYear.Text.ToString());
            if(newFormat.Text.ToString() == "PaperBack")
            {
                newBook.Format = BookFormat.PaperBack;
            }
            else if(newFormat.Text.ToString() == "EBook")
            {
                newBook.Format = BookFormat.EBook;
            }
            
            (lBooks.ItemsSource as List<Book>).Add(newBook);
            CollectionViewSource.GetDefaultView(lBooks.ItemsSource).Refresh();

            cpt++;
        }

        private void Button_Remove_Book(object sender, RoutedEventArgs e)
        {
            string message = "Do you really want to remove this book ?";
            string caption = "confirmation of removing the book";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
           

            // Displays the MessageBox.
            if(MessageBox.Show(message, caption, buttons) == MessageBoxResult.Yes)
            {
                (lBooks.ItemsSource as List<Book>).Remove(lBooks.SelectedItem as Book);
                CollectionViewSource.GetDefaultView(lBooks.ItemsSource).Refresh();
            };
            


            
        }
    }
}
