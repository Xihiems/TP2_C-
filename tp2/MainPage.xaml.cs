using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

//Yann Raymond
//IT1

namespace tp2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            
            InitializeComponent();
            
        }
        private void Button_Click(object sender, EventArgs e)
        {
            // the "??" operator checks for nullability and value all at once.
            // because ConvertCheckBox.IsChecked is of type __bool ?__ which
            // is a nullable boolean, so it can either be true, false or null
            var toDecrypt = checkbox.IsChecked;
            var inputText = InsertEditor.Text;

            if (toDecrypt)
            {
                OutputEditor.Text = $"{inputText} is gibberish and should be decrypted using Caesar method";
            }
            else
            {
                OutputEditor.Text = $"{inputText} was written as an input to be encrypted using Caesar method";
            }

            OutputEditor.Text = Caesar.Code(inputText, toDecrypt);
        }
    }

    // This class is not instantiated because it is static. 
    // You might not be able to do this so easily...
    // And each class should have its own file !
    internal static class Caesar
    {
        public static string Code(string inputText, bool toDecrypt)
        {
            // Ternary operator - Google it
            return toDecrypt ? Decrypt(inputText) : Encrypt(inputText);
        }

        private static string Encrypt(string inputText)
        {
            string output = string.Empty;

            foreach (char ch in inputText)
                output += cipher(ch,3);

            return $"{output} was encrypted with Caesar !";
        }  


        private static string Decrypt(string inputText)
        {
            string output1 = string.Empty;

            foreach (char ch in inputText)
                output1 += cipher(ch, -3);

            return $"{output1} was decrypted with Caesar !";

        }
        public static char cipher(char ch,int key)
        {
            if (!char.IsLetter(ch))
            {

                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);


        }
    }
}
