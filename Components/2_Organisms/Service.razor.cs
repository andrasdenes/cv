using Microsoft.AspNetCore.Components;

namespace cv.Components._2_Organisms
{
    public partial class Service
    {
        [Parameter]
        public string Icon { get; set; } = string.Empty;

        [Parameter]
        public string Name { get; set; } = string.Empty;

        [Parameter]
        public string Description { get; set; } = string.Empty;

        [Parameter]
        public bool Mirrored { get; set; } = false;

        [Parameter]
        public string ForCompanies { get; set; } = string.Empty;

        [Parameter]
        public string Anchor { get; set; } = string.Empty;
    }
}
