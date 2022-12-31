using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolkoIKrzyzykOkienkowaAplikacja
{
    public class MyOwnMessageClass
    {
        //public static System.Windows.Forms.DialogResult ShowMessage(string message, string caption)
        //{
        //    System.Windows.Forms.DialogResult dlgResult = System.Windows.Forms.DialogResult.None;
        //    using(resultMessage msgResult = new resultMessage())
        //    {
        //        msgResult.Text = caption;
        //        if(message == "Remis")
        //        {
        //            msgResult.Message = message;
        //            msgResult.Image = KolkoIKrzyzykOkienkowaAplikacja.Properties.Resources.crossInCircle;
        //        }
        //        else
        //        {
        //            msgResult.Message = "Wygraly: " + message;
        //            if (message == "O")
        //                msgResult.Image = KolkoIKrzyzykOkienkowaAplikacja.Properties.Resources.circle;
        //            else if (message == "X")
        //                msgResult.Image = KolkoIKrzyzykOkienkowaAplikacja.Properties.Resources.cross;
        //            else
        //                msgResult.Image = KolkoIKrzyzykOkienkowaAplikacja.Properties.Resources.question;
        //        }
        //        dlgResult = msgResult.ShowDialog();
        //    }
        //    return dlgResult;
        //}
        public static int ShowMessage(string message, string caption)
        {
            int choice = -1;
            using (resultMessage msgResult = new resultMessage())
            {
                msgResult.Text = caption;
                if (message == "Remis")
                {
                    msgResult.Message = message;
                    msgResult.Image = KolkoIKrzyzykOkienkowaAplikacja.Properties.Resources.crossInCircle;
                }
                else
                {
                    msgResult.Message = "Wygraly: " + message;
                    if (message == "O")
                        msgResult.Image = KolkoIKrzyzykOkienkowaAplikacja.Properties.Resources.circle;
                    else if (message == "X")
                        msgResult.Image = KolkoIKrzyzykOkienkowaAplikacja.Properties.Resources.cross;
                    else
                        msgResult.Image = KolkoIKrzyzykOkienkowaAplikacja.Properties.Resources.question;
                }
                msgResult.ShowDialog();
                choice = msgResult.Choice;
            }
            return choice;
        }
    }
}
