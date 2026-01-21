using Microsoft.AspNetCore.Http.Features;

namespace cv.Data.DTO
{
    public class CvProjectsAndInterests
    {
        public List<string> Items { get; set; } = new List<string>();
    }
}
