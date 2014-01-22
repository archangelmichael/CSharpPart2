using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*  Write a program that replaces in a HTML document 
 * given as string all the tags <a href="…">…</a> 
 * with corresponding tags [URL=…]…/URL]. 
 * Sample HTML fragment:
 * <p>Please visit <a href="http://academy.telerik. com">our site</a> to choose a training course.
 * Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>
    => 
 * <p>Please visit [URL=http://academy.telerik. com]our site[/URL] to choose a training course. 
 * Also visit [URL=www.devbg.org]our forum[/URL] to discuss the courses.</p> */
class HTMLFragements
{
    static void Main()
    {
        string input = Console.ReadLine();
        string replaced = input.Replace(@"<a href=""", "[URL=");
        replaced = replaced.Replace(@"</a>", "[/URL]");
        replaced = replaced.Replace(@""">", "]");
        Console.WriteLine(replaced);
        /* For shorter and more complex solution instead of 3 string.replace we get
         * Regex.Replace(input, "<a href=\"(.*?)\">(.*?)</a>", "[URL=$1]$2[/URL]") */
    }
}

