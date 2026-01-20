using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Localization;

namespace cv.Components.Meta
{
    public partial class CulturePicker
    {
        private void OnChange(ChangeEventArgs e)
        {
            var culture = e.Value?.ToString();
            if (string.IsNullOrWhiteSpace(culture)) return;

            var redirect = Uri.EscapeDataString(Nav.ToBaseRelativePath(Nav.Uri));
            Nav.NavigateTo($"/culture/set?culture={Uri.EscapeDataString(culture)}&redirectUri=/{redirect}", forceLoad: true);
        }
    }
}
