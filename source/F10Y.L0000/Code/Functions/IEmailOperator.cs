using System;
using System.Net;
using System.Net.Mail;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IEmailOperator
    {
        public MailAddress Get_MailAddress(string address)
        {
            var output = new MailAddress(address);
            return output;
        }

        public MailAddress Get_MailAddress(
            string address,
            string displayName)
        {
            var output = new MailAddress(
                address,
                displayName);

            return output;
        }

        public NetworkCredential Get_NetworkCredential(
            string username,
            string password)
        {
            var output = new NetworkCredential(
                username,
                password);

            return output;
        }

        public void Add_Address(
            MailMessage message,
            string address)
        {
            var mailAddress = this.Get_MailAddress(address);

            message.To.Add(mailAddress);
        }
    }
}
