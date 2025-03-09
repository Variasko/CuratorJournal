using System.Windows.Controls;
using System.Windows;
using Microsoft.Xaml.Behaviors;

public class PasswordBoxBehavior : Behavior<PasswordBox>
{
    public static readonly DependencyProperty PasswordProperty =
        DependencyProperty.Register(
            "Password",
            typeof(string),
            typeof(PasswordBoxBehavior),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public string Password
    {
        get => (string)GetValue(PasswordProperty);
        set => SetValue(PasswordProperty, value);
    }

    protected override void OnAttached()
    {
        AssociatedObject.PasswordChanged += OnPasswordChanged;
    }

    private void OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        Password = AssociatedObject.Password;
    }

    protected override void OnDetaching()
    {
        AssociatedObject.PasswordChanged -= OnPasswordChanged;
    }
}