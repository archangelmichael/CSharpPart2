using System;
using System.ComponentModel;
using System.Net;

/*  Write a program that downloads a file from Internet 
(e.g. http://www.devbg.org/img/Logo-BASD.jpg) 
and stores it the current directory. 
Find in Google how to download files in C#. 
Be sure to catch all exceptions and to free 
any used resources in the finally block.    */

class InternetFileDownload
{
    static void Main()
    {
        Console.WriteLine(@"Enter the address and name of the file you want to download: ");
        // can use: http://www.automedia.bg/files/articles_body/2013-07/4989965681382426560.jpg
        string source = Console.ReadLine();
        Console.WriteLine("Enter directory path to download the file: ");
        // can use: ../../picture.jpg
        string destination = Console.ReadLine();

        using (WebClient webClient = new WebClient())
        {
            try
            {
                webClient.DownloadFile(source,destination);
            }
            catch (ArgumentNullException)
            {
                Console.Error.WriteLine("No address entered.");
            }
            catch (WebException)
            {
                Console.Error.WriteLine("The address is invalid.");
            }
            catch (NotSupportedException)
            {
                Console.Error.WriteLine("The method has been called simultaneously on multiple threads.");
            }
        }
    }
}

