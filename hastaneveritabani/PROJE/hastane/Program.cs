using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hastane
{
    static class Program
    {
     
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles(); //Uygulama için görsel stiller sağlar
            Application.SetCompatibleTextRenderingDefault(false); //Uygulama kapsamında varsayılan değerini ayarlar 
            Application.Run(new Form1());  //Açılısta Form1 ekranı calisir 
        }
    }
}
