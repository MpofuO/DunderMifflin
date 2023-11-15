namespace Dunder_Mifflin_Paper_Company.Infrastructure
{
    public static class Helpers
    {
        public static string getSRC(byte[] Image)
        {
            if (Image != null)
            {
                string base64 = Convert.ToBase64String(Image);
                return $"data:image/*;base64,{base64}";
            }

            return "/images/dundermifflin.png";
        }
    }
}
