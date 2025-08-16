using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Opendeck.Win32.App.Extensions;

public static class ProgressRingExtensions
{
    public static void Show(this ProgressRing progressRing)
    {
        progressRing.IsActive = true;
        progressRing.Visibility = Visibility.Visible;
    }

    public static void Hide(this ProgressRing progressRing)
    {

        progressRing.IsActive = false;
        progressRing.Visibility = Visibility.Collapsed;
    }
}
