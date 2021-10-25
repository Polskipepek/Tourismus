﻿namespace Helpers.MailHelpers {
    public static class MailHelper {
        public static bool IsValidEmail(string email) {
            try {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            } catch {
                return false;
            }
        }
    }
}
