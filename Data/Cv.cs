using cv.Data.DTO;

namespace cv.Data
{
    public class Cv
    {
        public CvMeta Meta { get; set; }
        public CvBase Base { get; set; }
        public CvSummary Summary { get; set; }
        public List<CvPosition> Positions { get; set; } = new List<CvPosition>();
        public CvSkills TechnicalSkills { get; set; }
        public CvProjectsAndInterests ProjectsAndInterests { get; set; }

    }
}
