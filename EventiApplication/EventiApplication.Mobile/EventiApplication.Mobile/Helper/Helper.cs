using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace EventiApplication.Mobile.Helper
{
    public class Helper
    {
        public static bool ProvjeriMailFormat(string email)
        {
            try
            {
                var adress = new MailAddress(email);
                return adress.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
