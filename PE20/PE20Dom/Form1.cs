using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PE20Dom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            try
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\\WOW6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION",
                    true);
                key.SetValue(Application.ExecutablePath.Replace(Application.StartupPath + "\\", ""), 12001, Microsoft.Win32.RegistryValueKind.DWord);
                key.Close();
            }
            catch
            {

            }

            // add the delegate method to be called after the webpage loads, set this up before Navigate()
            this.webBrowser1.DocumentCompleted += new
            WebBrowserDocumentCompletedEventHandler(this.WebBrowser1__DocumentCompleted);

            // if you want to use example.html from a local folder (saved in c:\temp for example):
            this.webBrowser1.Navigate("c:\\temp\\example.html");

            // or if you want to use the URL  (only use one of these Navigate() statements)
            this.webBrowser1.Navigate("people.rit.edu/dxsigm/example.html");


        }

        private void WebBrowser1__DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser webBrowser = (WebBrowser)sender;
            HtmlElementCollection htmlElementCollection;
            HtmlElement htmlElement;

            
            //lock browers before editing
            lock (webBrowser1)
            {
                //change header1 
                htmlElementCollection = this.webBrowser1.Document.GetElementsByTagName("h1");
                htmlElement = htmlElementCollection[0];
                htmlElement.InnerText = "My UFO Page";

                //change first header2
                htmlElementCollection = this.webBrowser1.Document.GetElementsByTagName("h2");
                htmlElement = htmlElementCollection[0];
                htmlElement.InnerText = "My UFO Info";

                //change second header2
                htmlElement = htmlElementCollection[1];
                htmlElement.InnerText = "My UFO Pictures";

                //change third header2
                htmlElement = htmlElementCollection[2];
                htmlElement.InnerText = "";

                //change body styles
                htmlElementCollection = this.webBrowser1.Document.GetElementsByTagName("body");
                htmlElement = htmlElementCollection[0];
                htmlElement.Style = "font-family: Sans-Serif; color: #9b2220";

                //change paragraph one, including adding working link to website
                htmlElementCollection = this.webBrowser1.Document.GetElementsByTagName("p");
                htmlElement = htmlElementCollection[0];
                htmlElement.InnerText = "Report your UFO sightings here: ";

                //creation of "link" element to make a working link
                HtmlElement link = this.webBrowser1.Document.CreateElement("a");
                link.SetAttribute("href", "http://www.nuforc.org");
                link.InnerText = "www.nuforc.org";

                //append link to current htmlElement and change its styles
                htmlElement.AppendChild(link);
                htmlElement.Style = "color: green; font-weight: bold; font-size: 2em; text-transform: uppercase; text-shadow: 3px 2px #A44";

                //change second paragraph text, then add image
                htmlElement = htmlElementCollection[1];
                htmlElement.InnerText = "";

                //create "image" element to be added to second paragraph
                HtmlElement image = this.webBrowser1.Document.CreateElement("img");
                image.SetAttribute("src", "https://www.seti.org/sites/default/files/styles/original/public/2023-07/antique-UAP-envato-1200px.jpg?itok=ZpMp2_V4");
                htmlElement.AppendChild(image);

                //add footer to body of page
                htmlElementCollection = this.webBrowser1.Document.GetElementsByTagName("body");
                HtmlElement footer = this.webBrowser1.Document.CreateElement("footer");
                footer.InnerHtml = "<footer>&copy 2023 Andrew Black</footer>";
                htmlElement = htmlElementCollection[0];
                htmlElement.AppendChild(footer);

            //unlock webBrowser1
            }
            
        }

    }
}
