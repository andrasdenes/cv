namespace cv.Data.DTO
{
    public class CvBase
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public CvContact Contact {get;set;} = new CvContact();
    }
}
