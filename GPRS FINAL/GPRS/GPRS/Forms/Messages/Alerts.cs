using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPRS.Forms.Messages
{
    public static class Alerts
    {
        public static bool ShowWarning(string message)
        {
            bool response = false;

            if(new Warning(message).ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                response = true;
            }

            return response;
        }

        public static void ShowInformation(string message)
        {
            new Information(message).ShowDialog();
        }

        public static void ShowSuccess(string message)
        {
            new Success(message).ShowDialog();
        }

        public static void ShowError(string message)
        {
            new Error(message).ShowDialog();
        }
    }
}
