using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Security.Policy;
using System.Security.Cryptography;

namespace ProjectViolent
{
    public class PasswordBoxBehavior : Behavior<PasswordBox>
    {
        public static readonly DependencyProperty PasswordHashDependencyProperty = DependencyProperty.Register("PasswordHash", typeof(string), typeof(PasswordBoxBehavior));
        public static readonly DependencyProperty PasswordDependencyProperty = DependencyProperty.Register("Password", typeof(string), typeof(PasswordBoxBehavior));

        public string PasswordHash
        {
            get { return (string)GetValue(PasswordHashDependencyProperty); }
            set { SetValue(PasswordHashDependencyProperty, value); }
        }

        public string Password
        {
            get { return (string)GetValue(PasswordDependencyProperty); }
            set { SetValue(PasswordDependencyProperty, value); }
        }

        protected override void OnAttached()
        {
            base.OnAttached();

            // Присоединение обработчиков событий            
            this.AssociatedObject.PasswordChanged += AssociatedObject_PasswordChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            // Удаление обработчиков событий
            this.AssociatedObject.MouseLeftButtonDown -= AssociatedObject_PasswordChanged;
        }

        protected virtual void AssociatedObject_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = AssociatedObject.Password;
            PasswordHash = CalculateSecurePassword(AssociatedObject.Password);
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
        }

        protected string CalculateSecurePassword(string CurrentPassword)
        {
            if (CurrentPassword == null || CurrentPassword == "") return "";
            using (SHA256 hash = SHA256.Create())
            {
                return BitConverter.ToString(hash.ComputeHash(Encoding.UTF8.GetBytes(CurrentPassword))).Replace("-","");
            }
        }
    }
}
