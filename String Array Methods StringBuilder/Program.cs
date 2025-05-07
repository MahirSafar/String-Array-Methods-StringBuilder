using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Metadata;
using System.Xml.Linq;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace String_Array_Methods_StringBuilder
{
    internal class Program
    {
        static void Main(string[] args)
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

            #region Task1
            int[] arr = {-1,-2,-3,1,2,3,4,5};
            int [] array = { };
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
            Console.WriteLine(IsLetter(charLetter)? "Your word contains only letters." : "Your word does not contain only letters.");

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

        public static int[] ConvertNegativesToPositive(int[]arr)
        {
            if (arr?.Any() != true) 
            {
                Console.WriteLine("Array cannot be null or empty.");
            }

            for (int j = 0; j < arr.Length; j++)
            {
                if(arr[j] < 0) arr[j] *= -1;
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

            string lowered = palindrome.ToLower();
            string reversed = new string(lowered.Reverse().ToArray());

            if (lowered == reversed)
            {
                return "Your word is palindrome.";
            }

            return "Your word is not a palindrome.";

        }

        #endregion

        #region Task3

        public static string RemoveReplayedChar(string w)
        {
            string result = string.Empty;
            foreach (char c in w)
            {
                if (!result.Contains(c, StringComparison.OrdinalIgnoreCase))
                {
                    result += c;
                }
            }
            return result;
        }

        #endregion

        #region Task4

        public static void TextToWordByWord(string text)
        {
            string[] res = text.Split(' ');

            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }

        #endregion

        #region Task5

        public static string FirstFourChar(string word)
        {
            string result = word.TrimStart();

            if (result.Length < 4) return result;

            result = result.Substring(0, 4);

            return result;
        }

        #endregion

        #region Task6

        public static string TakeDomain(string email)
        {
            if (!string.IsNullOrWhiteSpace(email) || !email.Contains("@")) return "You should enter an email address.";

            string[] result = email.Split('@');

            return result[1];
        }

        #endregion

        #region Task7

        public static bool IsLetter(string charLetter)
        {
            char letter = ' ';
            for (int i = 0; i < charLetter.Length; i++)
            {
                letter = charLetter[i];

                if (!char.IsLetter(letter))
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
            sentence = sentence.TrimStart().ToLower();
            return char.ToUpper(sentence[0]) + sentence.Substring(1);
        }

        #endregion

        #region Task9

        public static string[] GetNamesOnly(string[] fullnames)
        {
            string[] names = new string[fullnames.Length];

            for (int i = 0; i < fullnames.Length; i++)
            {
                string fullname = fullnames[i].Trim();

                if (!string.IsNullOrEmpty(fullname))
                {
                    string[] parts = fullname.Split(' ');
                    names[i] = parts[0]; 
                }
            }

            return names;
        }

        #endregion
    }
}
