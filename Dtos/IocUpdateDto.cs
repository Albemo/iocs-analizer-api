namespace iocs_analizer_api.Dtos
{
    public class IocUpdateDto
    {
        public string Sha256 { get; set; }

        public string Sha1 { get; set; }

        public string Md5 { get; set; }

        public string Mcafee { get; set; }

        public string Engines { get; set; }
    }
}