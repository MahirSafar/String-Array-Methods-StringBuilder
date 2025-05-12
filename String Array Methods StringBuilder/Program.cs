using System;
using System.Linq;
using System.Text;

namespace String_Array_Methods_StringBuilder
{
    internal class Program
    {
        //1.int tipindən bir array olur içində müsbət və mənfi ədədlər olur elə bir method yazın ki,
        //bu array - i parametr olaraq qəbul etsin və qəbul etdiyi array-in əvvəlcədən assign olunması məcburi olsun
        //daha sonra içindəki mənfi ədədləri müsbətə çevirib həmin array-i geriyə qaytarsın
        //2.Verilmiş stringin Palindrome olub olmamağını yoxlayın.
        //3.Verilmiş stringin içərisindəki təkrarlanan karakterləri silin.
        //4.Verilmiş string bir mətnin içərisindəki boşluqlara qədər olan sözdəri ayrılıqda yazın.
        //5.Verilmiş strigin ilk 4 hərfini ekrana yazdırın.
        //6.Verilmiş email dəyərinin domain hissəni qaytaran metod(test @code.edu.az email-i daxil edilsə code.edu.az hiss'sini qaytarmalıdır)
        //7.Verilmiş yazının yalnız hərflərdən ibarət olub olmadığını tapan metod
        //8.Verilmiş yazının ilk hərfini böyük qalanlarını kiçik edib qaytaran metod
        //(Misaçün "saLAm nEceSen" yazısı daxil edilsə metoddan "Salam necesen" return olmalıdır)
        //9.Verilmiş fullnamelər siyahısından name - lər siyahısı düzəldən metod(ad soyadlar siyahısındaki adları kəsib yeni bir arraye doldurub qaytarmalıdır)
        static void Main(string[] args)
        {
            #region Task1
            int[] arr = { -1, -2, -3, 1, 2, 3, 4, 5 };
            int[] array = { };
            ConvertNegativesToPositive(array);
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region Task2
            string palindrome = "swas";
            Console.WriteLine(CheckPalindrome(palindrome));
            #endregion

            #region Task3
            string w = "asdassadfadkbriognslk";
            string res = RemoveReplayedChar(w);
            Console.WriteLine(res);
            #endregion

            #region Task4
            string text = "Hi ! How are you ?";
            TextToWordByWord(text);
            #endregion

            #region Task5
            string word = "    asdnaslad";
            Console.WriteLine(FirstFourChar(word));
            #endregion

            #region Task6
            string email = "mahir.gs@code.edu.az";
            Console.WriteLine(TakeDomain(email));
            #endregion

            #region Task7
            string charLetter = "sldanlg";
            Console.WriteLine(IsLetter(charLetter) ? "Your word contains only letters." : "Your word does not contain only letters.");
            #endregion

            #region Task8
            string sentence = "ksdaniUSKABSDNAKjsd asjalsJsd";
            Console.WriteLine(FirstLetterUpLowOthers(sentence));
            #endregion

            #region Task9
            string[] fullnames = { "Mahir Safarov", "Ulvi Mecid", "Yagmur Novruzov" };
            string[] names = GetNamesOnly(fullnames);

            Console.WriteLine("Names:");
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
            #endregion
        }

        #region Task1
        public static int[] ConvertNegativesToPositive(int[] arr)
        {
            if (arr?.Any() != true)
            {
                Console.WriteLine("Array cannot be null or empty.");
            }
            for (int j = 0; j < arr.Length; j++)
            {
                if (arr[j] < 0)
                    arr[j] *= -1;
            }
            return arr;
        }
        #endregion

        #region Task2
        public static string CheckPalindrome(string palindrome)
        {
            if (string.IsNullOrWhiteSpace(palindrome))
            {
                return "You cannot enter null, empty, or whitespace.";
            }

            StringBuilder lowered = new StringBuilder(palindrome.ToLower());
            StringBuilder reversed = new StringBuilder();

            for (int i = lowered.Length - 1; i >= 0; i--)
            {
                reversed.Append(lowered[i]);
            }

            return lowered.ToString() == reversed.ToString() ? "Your word is palindrome." : "Your word is not a palindrome.";
        }
        #endregion

        #region Task3
        public static string RemoveReplayedChar(string w)
        {
            StringBuilder result = new StringBuilder();
            foreach (char c in w)
            {
                if (!result.ToString().Contains(c.ToString()))
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }
        #endregion

        #region Task4
        public static void TextToWordByWord(string text)
        {
            StringBuilder sb = new StringBuilder(text);
            string[] res = sb.ToString().Split(' ');
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }
        #endregion

        #region Task5
        public static string FirstFourChar(string word)
        {
            StringBuilder result = new StringBuilder(word.TrimStart());
            return result.Length < 4 ? result.ToString() : result.ToString().Substring(0, 4);
        }
        #endregion

        #region Task6
        public static string TakeDomain(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                return "You should enter a valid email address.";

            StringBuilder result = new StringBuilder(email);
            int atIndex = result.ToString().IndexOf('@');
            return result.ToString().Substring(atIndex + 1);
        }
        #endregion

        #region Task7
        public static bool IsLetter(string charLetter)
        {
            StringBuilder sb = new StringBuilder(charLetter);
            foreach (char c in sb.ToString())
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Task8
        public static string FirstLetterUpLowOthers(string sentence)
        {
            StringBuilder sb = new StringBuilder(sentence.TrimStart().ToLower());
            sb[0] = char.ToUpper(sb[0]);
            return sb.ToString();
        }
        #endregion

        #region Task9
        public static string[] GetNamesOnly(string[] fullnames)
        {
            string[] names = new string[fullnames.Length];
            for (int i = 0; i < fullnames.Length; i++)
            {
                string fullname = fullnames[i].Trim();
                StringBuilder sb = new StringBuilder(fullname);
                string[] parts = sb.ToString().Split(' ');
                names[i] = parts[0];
            }
            return names;
        }
        #endregion
    }
}
